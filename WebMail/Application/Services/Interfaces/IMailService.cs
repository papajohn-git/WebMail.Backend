using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Domain.Entities;

namespace WebMail.Application.Services.Interfaces
{
	public interface IMailService
	{
		Task<Response> SendMail(int userId, MailCreateDTO mailDTO);
		Task<MailReadOnlyDTO?> GetMailByGuid(Guid mailGuid);
		Task<MailReadOnlyDTO?> GetMailById(int mailID);
		Task<Response> MoveEmailToFolder(int userId, Guid mailGuid, string folderName, string newFolderName);
		Task<Response> DeleteEmailFromFolder(int userId, Guid mailGuid, int folderId);
	}
}
