using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class FolderRepository : GenericRepository<Folder>, IFolderRepository
	{
		public FolderRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Folder?> CreateFolderAsync(int userId, string nameFolder)
		{
			User? user = await context.Users.FindAsync(userId);

			if (user == null) return null;

			var folder = new Folder
			{
				User = user,
				UserId = userId,
				FolderName = nameFolder
			};
			await context.Folders.AddAsync(folder);
			return folder;
		}

		public async Task<bool> CreateDefaultFoldersAsync(int userId)
		{
			// Check if the user exists
			var user = await context.Users.FindAsync(userId);
			if (user == null) return false;

			// Define the default folder names
			var defaultFolders = new List<string>
			{
				"Inbox",
				"Sent Items",
				"Deleted Items"
			};

			// Create default folders if they don't exist
			foreach (var folderName in defaultFolders)
			{
				var existingDefaultFolder = await context.Folders.
					Where(f => f.UserId == userId && f.FolderName == folderName)
					.FirstOrDefaultAsync();


				if (existingDefaultFolder == null)
				{
					var defaultFolder = new Folder
					{
						User = user,
						UserId = userId,
						FolderName = folderName
					};
					await context.Folders.AddAsync(defaultFolder);
				}
			}
			return true;
		}


		public async Task<IEnumerable<Folder?>> GetAllAsync(int userId)
		{
			return await context.Folders
				.Where(f => f.UserId == userId)
				.ToListAsync();
		}


		public async Task<Folder?> GetFolderByFolderNameAsync(int userId, string folderName)
		{
			return await context.Folders
				.Where(f => f.UserId == userId && f.FolderName == folderName)
				.FirstOrDefaultAsync();
		}

		public async Task<Folder?> GetFolderByFolderNameAsync(string userEmail, string folderName)
		{
			return await context.Folders
				.Where(f => f.User.Email == userEmail && f.FolderName == folderName)
				.FirstOrDefaultAsync();
		}

		public async Task<int?> GetFolderIdByName(int userId, string folderName)
		{
			var folder = await context.Folders
				.Where(f => f.UserId == userId && f.FolderName == folderName)
				.FirstOrDefaultAsync();

			return folder?.Id;
		}

		public async Task<Folder?> GetFolderByFolderIdAsync(int userId, int folderId)
		{
			return await context.Folders
				.Where(f => f.UserId == userId && f.Id == folderId)
				.FirstOrDefaultAsync();
		}

	}
}
