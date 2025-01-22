using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.User;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Domain.Enums.UserRole;
using WebMail.Infrastructure.Encryption;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class UserService : IUserService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<UserService> _logger;
		private readonly IMapper _mapper;

		public UserService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = new LoggerFactory().AddSerilog().CreateLogger<UserService>();
			_mapper = mapper;
		}

		public async Task<Response> SignUpUserAsync(UserSignUpDTO userDTO)
		{
			bool result = false;

			try 
			{
				Expression<Func<User, bool>> predicate = user => user.Email == userDTO.Email;
				var existingUsers = await _unitOfWork!.UserRepository.GetAllByPredicateAsync(predicate);

				if (existingUsers.Any())
				{
					throw new EntityAlreadyExistsException("", $"User with email {userDTO.Email} already exists.");
				}

				User? mappedUser = _mapper.Map<User>(userDTO);
				mappedUser.Password = EncryptionUtil.Encrypt(userDTO.Password!);

				await _unitOfWork.UserRepository.AddAsync(mappedUser);
				result = await _unitOfWork.SaveAsync();

				var defaultFolders = new List<string>
				{
					"Inbox",
					"Sent Items",
					"Deleted Items"
				};

				if (result)
				{
					mappedUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(userDTO.Email!);
					if (mappedUser != null)
					{
						foreach (var folderName in defaultFolders)
						{
							var existingDefaultFolder = await _unitOfWork.FolderRepository
								.GetFolderByFolderNameAsync(mappedUser.Id, folderName);

							if (existingDefaultFolder == null)
							{
								var defaultFolder = await _unitOfWork.FolderRepository.CreateFolderAsync(mappedUser.Id, folderName);
								if (defaultFolder == null)
								{
									_logger.LogError($"Failed to create default folder: {folderName} for user with email:" +
										$" {userDTO.Email}. The folder already exists");
									throw new ServerException("ServerError", $"Failed to create default folder: {folderName} " +
										$"for user with email: {userDTO.Email}. The folder already exists. Check logs file.");
								}
							}
						}
						await _unitOfWork.SaveAsync();
						//create a mail from team app
						var user = await _unitOfWork.UserRepository.GetUserByEmailAsync(userDTO.Email!);

						if (user == null)
						{
							throw new EntityNotFoundException("", $"User with email: {userDTO.Email} does not exist.");
						}
						var folderId = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(user!.Id, "Inbox");
						
						var teamAppMail = new Mail
						{
							GuidMail = Guid.NewGuid(),
							Recipients = new List<string> { user.Email },
							SenderEmail = "app_team@yourcompany.com",
							Subject = "Welcome to Our Service",
							Body = $"Welcome to our service! We're glad to have you on board.\n\nBest regards,\nThe App Team",
							SendAt = DateTime.UtcNow,
							FolderMails = new List<FolderMail>(),
							UserMails = new List<UserMail>()
						};

						await _unitOfWork.MailRepository.AddAsync(teamAppMail);
						await _unitOfWork.SaveAsync();

						var savedmail = await _unitOfWork.MailRepository.GetByGuidAsync(teamAppMail.GuidMail)
					?? throw new EntityNotFoundException("", $"Mail with guid {teamAppMail.GuidMail} does not exist.");


						var inboxFolder = await _unitOfWork.FolderRepository.GetFolderByFolderNameAsync(user.Id, "Inbox") ??
							throw new EntityNotFoundException("", $"Inbox folder does not exist.");

						if (inboxFolder != null)
						{
							var folderMail = new FolderMail
							{
								FolderId = inboxFolder.Id,
								MailId = savedmail.Id
							};
							await _unitOfWork.FolderMailRepository.AddAsync(folderMail);
						}

						var userMail = new UserMail
						{
							UserId = user.Id,
							MailId = savedmail.Id,
							ReceivedAt = DateTime.UtcNow
						};

						await _unitOfWork.UserMailRepository.AddAsync(userMail);
						result = await _unitOfWork.SaveAsync();

					}
				}

			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServerException("ServerError", $"An error occurred while sign-up the user, error message: {ex.Message}");
			}

			return result == true ? new Response(true, $"User with email: {userDTO.Email}, sign-up successfully") :
									throw new ServerException("ServerError", $"User with email: {userDTO.Email}, failed to be signed-up");
		}

		public async Task<Response> EmailExistsAsync(string email)
		{
			var existingUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(email);

			return existingUser is not null
			? new Response(true, $"User  with email {email} already exists.")
			: new Response(false, $"User  with email {email} does not exist.");
		}

		public async Task<UserReadOnlyDTO?> VerifyAndGetUserAsync(UserLoginDTO credentials)
		{
			User? user = await _unitOfWork.UserRepository.GetUserByEmailAsync(credentials.Email);
			if (user == null)
			{
				return null;
			}

			bool isPasswordValid = EncryptionUtil.IsValidPassword(credentials.Password, user.Password);
			if (!isPasswordValid)
			{
				return null;
			}

			return _mapper.Map<UserReadOnlyDTO>(user);
		}
		public string CreateUserToken (int userId, string email, UserRole? userRole, string appSecurityKey)
		{
			var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(appSecurityKey));
			var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, email),
				new Claim(ClaimTypes.NameIdentifier, userId.ToString()),
				new Claim(ClaimTypes.Role, userRole.ToString()!)
			};	

			var jwtSecurityToken = new JwtSecurityToken(
						issuer: "http://localhost:5000",
					  audience: "http://localhost:5000",
			            claims: claims,
					   expires: DateTime.Now.AddHours(24),
		    signingCredentials: signingCredentials
			);	

			var userToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

			return userToken;
		}

		public async Task<IEnumerable<UserEmailFullNameDTO?>> GetUserEmailFullName()
		{
			var users = await _unitOfWork.UserRepository.GetAllUsersMailsWithUserProfileAsync();
			var userEmailFullNames = _mapper.Map<IEnumerable<UserEmailFullNameDTO>>(users);

			return userEmailFullNames;
		}

		public async Task<IEnumerable<SupervisorUsersListReadOnlyDTO?>> GetSupervisorUsersListAsync()
		{
			var users = await _unitOfWork.UserRepository.GetAllUsersMailsWithUserProfileAsync();
			var supervisorUsersList = _mapper.Map<IEnumerable<SupervisorUsersListReadOnlyDTO>>(users);

			return supervisorUsersList;
		}

		public async Task<SupervisorUsersDetailsReadOnlyDTO?> GetSupervisorUsersDetailsByIdAsync(int userId)
		{
			var user = await _unitOfWork.UserRepository.GetUserWithUserProfileAsync(userId);
			if (user == null)
			{
				throw new EntityNotFoundException("", $"User with id: {userId} does not exist.");
			}

			var supervisorUsersDetails = _mapper.Map<SupervisorUsersDetailsReadOnlyDTO>(user);

			return supervisorUsersDetails;
		}

		public async Task<Response> UpdateSupervisorUsersDetailsAsync(SupervisorUsersUpdateDTO userDetails, int userId)
		{
			bool result = false;

			try
			{
				var user = await _unitOfWork.UserRepository.GetUserByIdAsync(userId);

				if (user == null)
				{
					throw new EntityNotFoundException("", $"User with id: {userId} does not exist.");
				}

				Expression<Func<User, bool>> predicate = user => user.Email == userDetails.Email;
				var existingUsers = await _unitOfWork!.UserRepository.GetAllByPredicateAsync(predicate);

				if (existingUsers.Any() && user.Id != existingUsers.First().Id)
				{
					throw new EntityAlreadyExistsException("", $"User with email {userDetails.Email} already exists.");
				}

				user = _mapper.Map(userDetails, user);

				await _unitOfWork.UserRepository.UpdateAsync(user);

				result = await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServerException("ServerError", $"An error occurred while updating the user details, error message: {ex.Message}");
			}

			return result == true ? new Response(true, $"User with id: {userId}, details updated successfully") :
									throw new ServerException("ServerError", $"User with id: {userId}, failed to be updated");
		}

		public async Task<Response> DeleteUserByIdAsync(int userId)
		{
			bool result = false;

			try
			{
				 await _unitOfWork.UserRepository.DeleteUserByIdAsync(userId);

				result = await _unitOfWork.SaveAsync();
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);
				throw new ServerException("ServerError", $"An error occurred while deleting the user, error message: {ex.Message}");
			}

			return result == true ? new Response(true, $"User with id: {userId}, deleted successfully") :
									throw new ServerException("ServerError", $"User with id: {userId}, failed to be deleted");
		}
	}
}
