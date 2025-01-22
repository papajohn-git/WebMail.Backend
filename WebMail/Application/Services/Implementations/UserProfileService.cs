using AutoMapper;
using Serilog;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.UserProfile;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class UserProfileService : IUserProfileService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<UserProfileService> _logger;
		private readonly IMapper _mapper;

		public UserProfileService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = new LoggerFactory().AddSerilog().CreateLogger<UserProfileService>();
			_mapper = mapper;
		}

		public async Task<UserProfileReadOnlyDTO?> GetUserProfile(string email)
		{
			UserProfile? userProfile = await _unitOfWork.UserProfileRepository.GetUserProfile(email);
			return userProfile == null ? new UserProfileReadOnlyDTO() : _mapper.Map<UserProfileReadOnlyDTO>(userProfile);
		}

		public async Task<UserProfileReadOnlyDTO?> GetUserProfile(int userId)
		{
			UserProfile? userProfile = await _unitOfWork.UserProfileRepository.GetUserProfile(userId);
			return userProfile == null? new UserProfileReadOnlyDTO() : _mapper.Map<UserProfileReadOnlyDTO>(userProfile);
		}

		public async Task<Response> UpdateUserProfileAsync(string email, UserProfilePatchDTO userProfile)
		{

			try
			{
				UserProfile? existingUserProfile = await _unitOfWork.UserProfileRepository.GetUserProfile(email);
				User? user = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);
				if (user == null)
				{
					throw new EntityNotFoundException("", $"User with email {email} does not exist.");
					//return new Response(false, $"User with email {email} does not exist.");
				}

				if (existingUserProfile == null)
				{
					existingUserProfile = new UserProfile
					{
						FirstName = userProfile.FirstName!,
						LastName = userProfile.LastName!,
						PhoneNumber = userProfile.PhoneNumber!,
						Address = userProfile.Address!,
						City = userProfile.City!,
						State = userProfile.State!,
						ZipCode = userProfile.ZipCode!,
						UserId = user.Id,
						User = user,
					};
					await _unitOfWork.UserProfileRepository.AddAsync(existingUserProfile);
					_logger.LogInformation($"User profile of {user.Email} init successfully.");
				}
				else
				{
					_mapper.Map(userProfile, existingUserProfile);
					await _unitOfWork.UserProfileRepository.UpdateAsync(existingUserProfile);
					_logger.LogInformation($"User profile of {user.Email} updated successfully.");
				}

				bool result = await _unitOfWork.SaveAsync();

				_logger.LogInformation(result
					? $"User profile updated for user with email {email}"
					: $"Failed to update user profile for user with email {email}");

				return new Response(result, result ? "User profile updated successfully." : throw new InvalidArgumentException("", "User profile faild to update"));

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "An error occurred while updating user profile.");
				//return new Response(false, "An error occurred while updating user profile.");
				throw new ServerException("ServerError", $"An error occurred while updating user profile, error message: {ex.Message}");
			}
			
		}

		public async Task<Response> UpdateUserProfileAsync(int userId, UserProfilePatchDTO userProfile)
		{
			UserProfile? existingUserProfile = await _unitOfWork.UserProfileRepository.GetUserProfile(userId);
			if (existingUserProfile == null)
			{
				//return new Response(false, $"User with id {userId} does not exist.");
				throw new EntityNotFoundException("", $"User with id {userId} does not exist.");
			}

			_mapper.Map(userProfile, existingUserProfile);
			await _unitOfWork.UserProfileRepository.UpdateAsync(existingUserProfile);
			bool result = await _unitOfWork.SaveAsync();

			_logger.LogInformation(result
				? $"User  profile updated for user with id {userId}"
				: $"Failed to update user profile for user with id {userId}");
			return new Response(result, result ? "User profile updated successfully." : throw new InvalidArgumentException("", "Failed to update user profile."));
		}


	}
}
