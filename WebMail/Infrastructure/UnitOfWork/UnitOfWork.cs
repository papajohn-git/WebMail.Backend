using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Implementations;

namespace WebMail.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public UserRepository UserRepository => new(_context);
		public FolderRepository FolderRepository => new(_context);
		public UserProfileRepository UserProfileRepository => new(_context);
		public MailRepository MailRepository => new(_context);
		public UserMailRepository UserMailRepository => new(_context);
		public FolderMailRepository FolderMailRepository => new(_context);
		public TodoRepository TodoRepository => new(_context);

		public async Task<bool> SaveAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
