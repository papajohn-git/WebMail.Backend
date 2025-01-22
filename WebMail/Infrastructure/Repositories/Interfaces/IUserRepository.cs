using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByEmailAsync(string email);
        Task<User?> GetUserByIdAsync(int id);
        Task<User?> GetUserAsync(string email, string password);
		Task<IEnumerable<User?>> GetAllUsersMailsWithUserProfileAsync();
		Task<User?> GetUserWithUserProfileAsync(int userId);
		Task<bool> DeleteUserByIdAsync(int userId);
	}
}
