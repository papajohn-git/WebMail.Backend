using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.User
{
	public class UserReadOnlyDTO
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public UserRole? UserRole { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
	}
}
