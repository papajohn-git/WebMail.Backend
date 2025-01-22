using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class FolderMailRepository : GenericRepository<FolderMail>, IFolderMailRepository
	{
		public FolderMailRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<int> CountMailsAsync(int folderId)
		{
			return await context.FolderMails
				.Where(fm => fm.FolderId == folderId)
				.CountAsync();
		}

		public async Task<FolderMail?> GetFolderMailByMailIdAndFolderIdAsync(int userId, int folderId)
		{
			return await context.FolderMails
				.Where(fm => fm.Mail.SenderId == userId && fm.FolderId == folderId)
				.FirstOrDefaultAsync();
		}

		public async Task<bool> DeleteByFolderIdAndMailId(int folderId, int mailId)
		{
			var folderMail = await context.FolderMails
				.Where(fm => fm.FolderId == folderId && fm.MailId == mailId)
				.FirstOrDefaultAsync();

			if (folderMail == null)
			{
				return false;
			}

			context.FolderMails.Remove(folderMail);

			return true;
		}

		public async Task<bool> PatchFolderMail(int folderId, int mailId, int newFolderId)
		{
			var folderMailToUpdate = await context.FolderMails
				.Where(fm => fm.FolderId == folderId && fm.MailId == mailId)
				.FirstOrDefaultAsync();

			if (folderMailToUpdate == null)
			{
				return false;
			}

			folderMailToUpdate.FolderId = newFolderId;

			return true;
		}

	}
}
