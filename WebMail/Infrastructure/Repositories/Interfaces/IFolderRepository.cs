using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
    public interface IFolderRepository
    {
		Task<Folder?> GetFolderByFolderNameAsync(int userId, string folderName);
		Task<Folder?> GetFolderByFolderIdAsync(int userId, int folderId);
		Task<Folder?> GetFolderByFolderNameAsync(string userEmail, string folderName);
        Task<int?> GetFolderIdByName(int userId, string folderName);
		Task<IEnumerable<Folder?>> GetAllAsync(int userId);
		Task<Folder?> CreateFolderAsync(int userId, string nameFolder);
        Task<bool> CreateDefaultFoldersAsync(int userId);
    }
}
