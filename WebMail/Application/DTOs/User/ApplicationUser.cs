using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.User
{
	public class ApplicationUser
	{
		public int? Id { get; set; }
		public string? Email { get; set; } = null!;
		public UserRole? UserRole { get; set; }

	}
}
