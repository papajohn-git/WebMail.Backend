using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.JWT;
using WebMail.Application.DTOs.User;
using WebMail.Application.DTOs.UserProfile;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Implementations;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Controllers
{
	public class UserController : BaseController
	{
		private readonly IConfiguration _configuration;

		public UserController(IApplicationService applicationService, IConfiguration configuration) : base(applicationService)
		{
			_configuration = configuration;
		}

		[HttpPost]
		public async Task<IActionResult> Register([FromBody] UserSignUpDTO userDTO)
		{
			var validationResults = new List<ValidationResult>();
			var validationContext = new ValidationContext(userDTO);
			bool isValid = Validator.TryValidateObject(userDTO, validationContext, validationResults, true);

			if (!isValid)
			{
				var errorMessages = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
				throw new InvalidArgumentException("", $"User with email: {userDTO.Email}, failed to be signed-up. Validation failed: {errorMessages}");
				
			}

			var result = await _applicationService.UserService.SignUpUserAsync(userDTO);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPost]
		public async Task<IActionResult> Login ([FromBody] UserLoginDTO credential)
		{
			var user = await _applicationService.UserService.VerifyAndGetUserAsync(credential);
			if (user == null)
			{
				throw new InvalidArgumentException("", $"User with email: {credential.Email}, failed to be signed-in. Invalid credentials.");
			}

			var userToken = _applicationService.UserService.CreateUserToken(user.Id, user.Email!, user.UserRole, _configuration["Authentication:SecretKey"]!);

			JwtTokenDTO token = new()
			{
				Token = userToken
			};

			return Ok(token);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> UpdateProfile([FromBody] UserProfilePatchDTO userDTO)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");
			var result = await _applicationService.UserProfileService.UpdateUserProfileAsync(AppUser.Email!, userDTO);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetProfile()
		{
			var userId = AppUser!.Id;
			if (userId == null)
			{
				throw new EntityForbiddenException("", "User is not authenticated.");
			}

			var result = await _applicationService.UserProfileService.GetUserProfile(AppUser.Email!);

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "User not found");
		}

		[HttpPost]
		public async Task<IActionResult> UserExist([FromBody] string email)
		{
			var result = await _applicationService.UserService.EmailExistsAsync(email);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetUserMailsFullName()
		{
			var userId = AppUser!.Id;
			if (userId == null)
			{
				throw new EntityForbiddenException("", "User is not authenticated.");
			}

			var result = await _applicationService.UserService.GetUserEmailFullName();

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "Users not found");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetSupervisorUsersList()
		{
			var result = await _applicationService.UserService.GetSupervisorUsersListAsync();

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "Users not found");
		}

		[HttpGet]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> GetSupervisorUsersDetailsList(int userId)
		{
			var result = await _applicationService.UserService.GetSupervisorUsersDetailsByIdAsync(userId);

			return result is not null ? Ok(result) : throw new EntityNotFoundException("", "User not found");
		}

		[HttpPost]
		[Authorize(Roles = "Admin")]
		public async Task<IActionResult> UpdateSupervisorUsersDetails([FromBody] SupervisorUsersUpdateDTO userDetails)
		{
			var validationResults = new List<ValidationResult>();
			var validationContext = new ValidationContext(userDetails);
			bool isValid = Validator.TryValidateObject(userDetails, validationContext, validationResults, true);

			if (!isValid)
			{
				var errorMessages = string.Join(", ", validationResults.Select(vr => vr.ErrorMessage));
				throw new InvalidArgumentException("", $"User with idl: {userDetails.Id}, failed to be signed-up. Validation failed: {errorMessages}");

			}

			var result = await _applicationService.UserService.UpdateSupervisorUsersDetailsAsync(userDetails, userDetails.Id);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpDelete]
		[Authorize(Roles ="Admin")]
		public async Task<IActionResult> DeleteUser(int userId)
		{
			var result = await _applicationService.UserService.DeleteUserByIdAsync(userId);

			return result.Success ? Ok(result) : BadRequest(result);
		}
	}
}
