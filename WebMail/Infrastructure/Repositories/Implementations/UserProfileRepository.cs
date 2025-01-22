using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class UserProfileRepository : GenericRepository<UserProfile>, IUserProfileRepository
	{
		public UserProfileRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<UserProfile?> GetUserProfile(string email)
		{
			return await context.UserProfiles
				.Where(up => up.User.Email == email)
				.FirstOrDefaultAsync();
		}

		public async Task<UserProfile?> GetUserProfile(int userId)
		{
			return await context.UserProfiles
				.Where(up => up.UserId == userId)
				.FirstOrDefaultAsync();
		}
	}
}