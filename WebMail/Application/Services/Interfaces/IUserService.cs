using WebMail.Application.DTOs.User;
using WebMail.Application.ApiResponse;
using WebMail.Domain.Entities;

namespace WebMail.Application.Services.Interfaces
{
	public interface IUserService
	{
		Task<Response> SignUpUserAsync(UserSignUpDTO request);
		Task<Response> EmailExistsAsync(string email);
		Task<UserReadOnlyDTO?> VerifyAndGetUserAsync(UserLoginDTO credentials);
		Task<IEnumerable<UserEmailFullNameDTO?>> GetUserEmailFullName();
		Task<IEnumerable<SupervisorUsersListReadOnlyDTO?>> GetSupervisorUsersListAsync();
		Task<SupervisorUsersDetailsReadOnlyDTO?> GetSupervisorUsersDetailsByIdAsync(int userId);
		Task<Response> UpdateSupervisorUsersDetailsAsync(SupervisorUsersUpdateDTO userDetails, int userId);
		Task<Response> DeleteUserByIdAsync(int userId);
	}
}
