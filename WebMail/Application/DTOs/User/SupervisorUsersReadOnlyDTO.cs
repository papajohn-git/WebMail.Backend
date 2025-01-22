using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.User
{
	public class SupervisorUsersDetailsReadOnlyDTO
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? ConfirmPassword { get; set; }
		public string? UserRole { get; set; }
		public DateTime? UserCreatedAt { get; set; }
		public DateTime? UserUpdatedAt { get; set; }
		public string? FirstName { get; set; }
		public string? LastName { get; set; }
		public string? PhoneNumber { get; set; }
		public string? Address { get; set; }
		public string? City { get; set; }
		public string? State { get; set; }
		public string? ZipCode { get; set; }
		public DateTime? UserProfileCreatedAt { get; set; }
		public DateTime? UserProfileUpdatedAt { get; set; }
	}
}
