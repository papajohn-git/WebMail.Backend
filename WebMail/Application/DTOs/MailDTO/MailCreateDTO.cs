using WebMail.Domain.Enums.UserRole;

namespace WebMail.Application.DTOs.MailDTO
{
	public class MailCreateDTO
	{
		public string? Subject { get; set; }
		public string? Body { get; set; }
		public IList<string>? Recipients { get; set; }
	}
}
