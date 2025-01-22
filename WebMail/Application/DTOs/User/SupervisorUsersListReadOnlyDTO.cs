using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.User
{
	public class SupervisorUsersListReadOnlyDTO
	{
		public int Id { get; set; }
		public string? Email { get; set; }
		public string? UserRole { get; set; }
		public DateTime? UserCreatedAt { get; set; }
	}
}
