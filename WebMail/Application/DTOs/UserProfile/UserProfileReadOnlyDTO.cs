using System.ComponentModel.DataAnnotations;

namespace WebMail.Application.DTOs.UserProfile
{
	public class UserProfileReadOnlyDTO
	{
		public string FirstName { get; set; } = null!;
		public string LastName { get; set; } = null!;
		public string PhoneNumber { get; set; } = null!;
		public string Address { get; set; } = null!;
		public string City { get; set; } = null!;
		public string State { get; set; } = null!;
		public string ZipCode { get; set; } = null!;
	}
}
