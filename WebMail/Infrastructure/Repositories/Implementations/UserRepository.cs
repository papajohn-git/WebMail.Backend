using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Encryption;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<User?> GetUserAsync(string email, string password)
        {
            var user = await context.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);

			if (user == null)
			{
				return null;
			}
			if (!EncryptionUtil.IsValidPassword(password, user.Password!))
			{
				return null;
			}
			return user;
		}

		public async Task<User?> GetUserByEmailAsync(string email)
		{
			return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<User?> GetUserByIdAsync(int id)
		{
			return await context.Users.FirstOrDefaultAsync(u => u.Id == id);
		}

		public async Task<IEnumerable<User?>> GetAllUsersMailsWithUserProfileAsync()
		{
			var users = await context.Users
								.Include(u => u.UserProfile)
								.ToListAsync();

			return users ?? Enumerable.Empty<User?>();
		}

		public async Task<User?> GetUserWithUserProfileAsync(int userId)
		{
			return await context.Users
				.Include(u => u.UserProfile)
				.FirstOrDefaultAsync(u => u.Id == userId);
		}

		public async Task<bool> DeleteUserByIdAsync(int userId)
		{
			var user = await context.Users
				.Include(u => u.UserProfile)
			    .Include(u => u.ToDos)
			    .Include(u => u.Folders)
			    .Include(u => u.UserMails)
			    .FirstOrDefaultAsync(u => u.Id == userId);

			if (user == null)
			{
				return false;
			}

			context.Users.Remove(user);
			return true;
		}
	}
}
