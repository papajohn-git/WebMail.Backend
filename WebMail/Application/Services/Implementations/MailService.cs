using AutoMapper;
using Serilog;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class MailService : IMailService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<MailService> _logger;
		private readonly IMapper _mapper;

		public MailService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = new LoggerFactory().AddSerilog().CreateLogger<MailService>();
			_mapper = mapper;
		}

		public async Task<Response> SendMail(int userId, MailCreateDTO mailDTO)
		{
			bool result;
			try
			{
				User? user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId)
				?? throw new EntityNotFoundException("", $"User with id {userId} does not exist.");

				var mail = new Mail
				{
					SenderId = userId,
					SenderEmail = user.Email,
					GuidMail = Guid.NewGuid(),
					Recipients = mailDTO.Recipients,
					Subject = mailDTO.Subject,
					Body = mailDTO.Body,
					SendAt = DateTime.UtcNow,
					FolderMails = new List<FolderMail>(),
					UserMails = new List<UserMail>()
				};

				await _unitOfWork.MailRepository.AddAsync(mail);
				await _unitOfWork.SaveAsync();

				var savedmail = await _unitOfWork.MailRepository.GetByGuidAsync(mail.GuidMail)
					?? throw new EntityNotFoundException("", $"Mail with guid {mail.GuidMail} does not exist.");


				var sentItemsFolder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(userId, "Sent Items") ??
					throw new EntityNotFoundException("", $"Sent Items folder does not exist.");

				if (sentItemsFolder != null)
				{
					var folderMail = new FolderMail
					{
						FolderId = sentItemsFolder.Id,
						MailId = savedmail.Id
					};

					await _unitOfWork.FolderMailRepository.AddAsync(folderMail);
				}

				if (mailDTO.Recipients == null || mailDTO.Recipients.Count == 0)
				{
					throw new EntityNotFoundException("", "Recipients list is empty.");
				}

				foreach (var recipientEmail in mailDTO.Recipients)
				{
					var inboxFolder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(recipientEmail, "Inbox")
						?? throw new EntityNotFoundException("", $"Inbox folder does not exist.");

					if (inboxFolder != null)
					{
						var folderMail = new FolderMail
						{
							FolderId = inboxFolder.Id,
							MailId = savedmail.Id
						};

						await _unitOfWork.FolderMailRepository.AddAsync(folderMail);

					}

					User? recipient = await _unitOfWork.UserRepository.GetUserByEmailAsync(recipientEmail)
						?? throw new EntityNotFoundException("", $"User with email {recipientEmail} does not exist.");

					var userMail = new UserMail
					{
						UserId = recipient.Id,
						MailId = savedmail.Id,
						ReceivedAt = DateTime.UtcNow
					};

					await _unitOfWork.UserMailRepository.AddAsync(userMail);
				}

			 result = await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error sending mail.");
				throw;
			}

			return new Response(result, "Mail sent successfully.");
		}

		public async Task<MailReadOnlyDTO?> GetMailByGuid(Guid guidMail)
		{
			Mail? mail = await _unitOfWork.MailRepository.GetByGuidAsync(guidMail)
				?? throw new EntityNotFoundException("", $"Mail with guid {guidMail} does not exist.");

			var mailDTO = _mapper.Map<MailReadOnlyDTO>(mail);

			return mailDTO;
		}

		public async Task<MailReadOnlyDTO?> GetMailById(int mailID)
		{
			var mails = await _unitOfWork.MailRepository.GetMailById(mailID);

			var mailDTOs = _mapper.Map<MailReadOnlyDTO>(mails);

			return mailDTOs;

		}

		public async Task<Response> MoveEmailToFolder(int userId, Guid mailGuid, string folderName, string newFolderName)
		{
			bool result;
			try
			{
				var mail = await _unitOfWork.MailRepository.GetByGuidAsync(mailGuid)
					?? throw new EntityNotFoundException("", $"Mail with guid {mailGuid} does not exist.");

				var folder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(userId, folderName)
					?? throw new EntityNotFoundException("", $"Folder with name {folderName} and user id: {userId}, does not exist.");

				var newFolder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(userId, newFolderName)
					?? throw new EntityNotFoundException("", $"Folder with name {newFolderName} and user id: {userId}, does not exist.");

				var newFolderMail = new FolderMail
				{
					FolderId = newFolder.Id,
					MailId = mail.Id
				};

				await DeleteEmailFromFolder(userId, mailGuid, folder.Id);

				await _unitOfWork.FolderMailRepository.AddAsync(newFolderMail);

				result = await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error moving mail to folder.");
				throw;
			}

			return new Response(result, "Mail moved to folder successfully.");
		}

		public async Task<Response> DeleteEmailFromFolder(int userId, Guid mailGuid, int folderId)
		{
			bool result;
			try
			{
				var mail = await _unitOfWork.MailRepository.GetByGuidAsync(mailGuid)
					?? throw new EntityNotFoundException("", $"Mail with guid {mailGuid} does not exist.");

				var folder = await _unitOfWork.FolderRepository.GetFolderByFolderIdAsync(userId, folderId)
					?? throw new EntityNotFoundException("", $"Folder with id {folderId} and user id: {userId}, does not exist.");

				bool isDeleted = await _unitOfWork.FolderMailRepository.DeleteByFolderIdAndMailId(folder.Id, mail.Id);
				if (!isDeleted)
				{
					throw new EntityNotFoundException("", $"Mail with id {mail.Id} does not exist in folder with id {folder.Id}.");
				}

				result = await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Error deleting mail from folder.");
				throw;
			}

			return new Response(result, "Mail deleted from folder successfully.");
		}
	}
}
