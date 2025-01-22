using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
	public interface IFolderMailRepository
	{
		Task<int> CountMailsAsync(int folderId);
		Task<FolderMail?> GetFolderMailByMailIdAndFolderIdAsync(int userId, int folderId);
		Task<bool> DeleteByFolderIdAndMailId(int folderId, int mailId);
		Task<bool> PatchFolderMail(int folderId, int mailId, int newFolderId);
	}
}
