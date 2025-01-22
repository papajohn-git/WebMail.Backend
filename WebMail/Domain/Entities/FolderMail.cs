namespace WebMail.Domain.Entities
{
	public class FolderMail
	{
		public int FolderId { get; set; }
		public int MailId { get; set; }
		// Navigation properties
		public virtual Folder Folder { get; set; } = null!;
		public virtual Mail Mail { get; set; } = null!;
	}
}
