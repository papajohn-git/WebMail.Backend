using System.ComponentModel.DataAnnotations;
using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.User
{
	public class SupervisorUsersUpdateDTO
	{
		[Required]
		public int Id { get; set; }
		[Required]
		public required string Email { get; set; }
		[Required]
		public required string UserRole { get; set; }
	}
}
