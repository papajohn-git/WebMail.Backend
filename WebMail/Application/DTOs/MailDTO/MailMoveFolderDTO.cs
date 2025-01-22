namespace WebMail.Application.DTOs.MailDTO
{
	public class MailMoveFolderDTO
	{
		public Guid GuidMail { get; set; }
		public required string FolderName { get; set; }
		public required string NewFolderName { get; set; }
	}
}
