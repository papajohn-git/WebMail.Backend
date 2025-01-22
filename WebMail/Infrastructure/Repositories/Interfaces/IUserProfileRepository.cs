using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
	public interface IUserProfileRepository
	{
		Task<UserProfile?> GetUserProfile(string email);
		Task<UserProfile?> GetUserProfile(int userId);
	}
}
