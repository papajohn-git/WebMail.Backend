using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
    public interface IMailRepository
    {
        Task<Mail?> GetByGuidAsync(Guid mailGuid);
		Task<IEnumerable<Mail?>> GetMailsByFolderIdAsync(int folderId);
		Task<Mail?> GetMailByGuidAsync(Guid mailGuid);
		Task<Mail?> GetMailById(int mailID);
	}
}
