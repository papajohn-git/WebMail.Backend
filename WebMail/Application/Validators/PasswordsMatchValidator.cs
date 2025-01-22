using System.ComponentModel.DataAnnotations;
using WebMail.Application.DTOs.User;

namespace WebMail.Application.Validators
{
	public class PasswordsMatchValidator : ValidationAttribute
	{
		protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
		{
			var user = (UserSignUpDTO)validationContext.ObjectInstance;

			if (user.Password != user.ConfirmPassword)
			{
				return new ValidationResult("Passwords do not match.");
			}

			return ValidationResult.Success;
		}

	}
}
