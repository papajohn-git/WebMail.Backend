using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.UserProfile;
using WebMail.Domain.Entities;

namespace WebMail.Application.Services.Interfaces
{
	public interface IUserProfileService
	{
		Task<UserProfileReadOnlyDTO?> GetUserProfile(string email);
		Task<UserProfileReadOnlyDTO?> GetUserProfile(int userId);
		Task<Response> UpdateUserProfileAsync(string email, UserProfilePatchDTO userProfile);
		Task<Response> UpdateUserProfileAsync(int userId, UserProfilePatchDTO userProfile);
	}
}
