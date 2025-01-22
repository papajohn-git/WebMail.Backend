using AutoMapper;
using Serilog;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.Folder;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class FolderService : IFolderService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<FolderService> _logger;
		private readonly IMapper _mapper;

		public FolderService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = new LoggerFactory().AddSerilog().CreateLogger<FolderService>();
			_mapper = mapper;
		}

		public async Task<IEnumerable<FolderReadOnlyDTO?>> GetAllUserFolder(int userId)
		{
			IEnumerable<Folder?> folders = await _unitOfWork.FolderRepository.GetAllAsync(userId);
			return _mapper.Map<IEnumerable<FolderReadOnlyDTO?>>(folders);

		}

		public async Task<int?> CountFolderMails(int userId, int folderId)
		{
			return await _unitOfWork.FolderRepository.GetFolderIdByName(userId, folderId.ToString());
		}

		public async Task<int?> CountFolderMails(int userId, string folderName)
		{
			return await _unitOfWork.FolderRepository.GetFolderIdByName(userId, folderName);
		}

		public async Task<IEnumerable<MailReadOnlyDTO?>> GetMailsFromFolderAsync(int userId, string nameFolder)
		{
			Folder? folder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(userId, nameFolder);
			if (folder == null)
			{
				throw new EntityNotFoundException("", $"Folder with name {nameFolder} does not exist.");
			}

			IEnumerable<Mail?> mails = Array.Empty<Mail>(); 
				mails = await _unitOfWork.MailRepository.GetMailsByFolderIdAsync(folder.Id);

			return _mapper.Map<IEnumerable<MailReadOnlyDTO?>>(mails);
		}

		public async Task<Response> CreateFolder(int userId, string folderName)
		{
			var result = false;   
			var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

			if (user == null)
			{
				return new Response(false, $"User with id {userId} does not exist.");
			}


			Folder? folder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(userId, folderName);
			if (folder != null)
			{
				return new Response(false, $"Folder with name {folderName} already exists.");
			}

			folder = new Folder
			{
				User = user,
				FolderName = folderName,
				UserId = userId
			};

			await _unitOfWork.FolderRepository.AddAsync(folder);
			 result = await _unitOfWork.SaveAsync();

			return result ? new Response(true, $"Folder with name {folderName} created successfully.") 
				: new Response(false, $"Folder with name {folderName} failed to be created.");
		}

		public async Task<Response> DeleteFolder(int userId, int folderId)
		{
			var result = false;
			var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

			if (user == null)
			{
				return new Response(false, $"User with id {userId} does not exist.");
			}

			Folder? folder = await _unitOfWork.FolderRepository.GetFolderByFolderIdAsync(userId, folderId);
			if (folder == null)
			{
				return new Response(false, $"Folder with id {folderId} does not exist.");
			}

			await _unitOfWork.FolderRepository.DeleteAsync(folder.Id);
			result = await _unitOfWork.SaveAsync();

			return result ? new Response(true, $"Folder with id {folderId} deleted successfully.")
				: new Response(false, $"Folder with id {folderId} failed to be deleted.");
		}	
	}
}
