using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Domain.Enums.UserRole;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class MailRepository : GenericRepository<Mail>, IMailRepository
	{
		public MailRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<Mail?> GetByGuidAsync(Guid mailGuid)
		{
			return await context.Mails.Where(m => m.GuidMail == mailGuid).FirstOrDefaultAsync();
		}

		public async Task<IEnumerable<Mail?>> GetMailsByFolderIdAsync(int folderId)
		{
			return await context.FolderMails
				.Where(fm => fm.FolderId == folderId)
				.Include(fm => fm.Mail)
				.ThenInclude(m => m.UserMails)
				.Select(fm => fm.Mail)
				.ToListAsync() ?? [];
		}

		public async Task<Mail?> GetMailByGuidAsync(Guid mailGuid)
		{
			return await context.Mails
				.Where(m => m.GuidMail == mailGuid)
				.Include(m => m.UserMails)
				.FirstOrDefaultAsync();
		}

		public async Task<Mail?> GetMailById(int mailID)
		{
			return await context.Mails
				.Where(m => m.Id == mailID)
				.Include(m => m.UserMails)
				.FirstOrDefaultAsync();
		}
	}
}
