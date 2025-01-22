namespace WebMail.Application.DTOs.MailDTO
{
	public class MailReadOnlyDTO
	{
		public Guid GuidMail { get; set; }
		public string? Subject { get; set; }
		public string? Body { get; set; }
		public string? SenderEmail { get; set; }
		public IList<string>? Recipients { get; set; }
		public DateTime SendAt { get; set; }
		public bool IsRead { get; set; }
		public DateTime ReceivedAt { get; set; }
		public DateTime? ReadAt { get; set; }

	}
}
