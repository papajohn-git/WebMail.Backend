using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.Folder;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Domain.Entities;

namespace WebMail.Application.Services.Interfaces
{
	public interface IFolderService
	{
		Task<IEnumerable<FolderReadOnlyDTO?>> GetAllUserFolder (int userId);
		Task<int?> CountFolderMails (int userId, int folderId);
		Task<int?> CountFolderMails(int userId, string folderName);
		Task<IEnumerable<MailReadOnlyDTO?>> GetMailsFromFolderAsync(int userId, string nameFolder);
		Task<Response> CreateFolder(int userId, string folderName);
		Task<Response> DeleteFolder(int userId, int folderId);
	}
}
