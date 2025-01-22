using System.ComponentModel.DataAnnotations;

namespace WebMail.Application.DTOs.UserProfile
{
	public class UserProfilePatchDTO
	{
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "First Name should be between 2 and 100 characters.")]
		public string? FirstName { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Last Name should be between 2 and 100 characters.")]
		public string? LastName { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Phone Number should be between 2 and 100 characters.")]
		public string? PhoneNumber { get; set; }
		[Required]
		[StringLength(50, MinimumLength = 2, ErrorMessage = "Address should be between 2 and 50 characters.")]
		public string? Address { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "City should be between 2 and 100 characters.")]
		public string? City { get; set; }
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "State should be between 2 and 100 characters.")]
		public string? State { get; set; }
		[Required]
		[StringLength(10, MinimumLength = 5, ErrorMessage = "ZipCode must be between 5 and 10 digits.")]
		public string? ZipCode { get; set; }
	}
}
