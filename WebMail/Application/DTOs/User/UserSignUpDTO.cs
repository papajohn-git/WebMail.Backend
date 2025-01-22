using System.ComponentModel.DataAnnotations;

namespace WebMail.Application.DTOs.User
{
	public class UserSignUpDTO
	{

		[StringLength(50, MinimumLength = 5, ErrorMessage = "Email must be between 5 and 50 characters long.")]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public string? Email { get; set; }

		[StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 10 characters long.")]
		//[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d)(?=.*?\W).{8,}$",
		//ErrorMessage = "Password must contain at least one uppercase letter, " +
		//	"one lowercase letter, one digit, and one special character.")]
		public string? Password { get; set; }

		[StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 10 characters long.")]
		//[RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?\d)(?=.*?\W).{8,}$",
		//ErrorMessage = "Password must contain at least one uppercase letter, " +
		//	"one lowercase letter, one digit, and one special character.")]
		public string? ConfirmPassword { get; set; }

	}
}
