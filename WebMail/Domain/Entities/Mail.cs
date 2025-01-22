using WebMail.Domain.Enums.UserRole;

namespace WebMail.Domain.Entities
{
    public class Mail : BaseEntity
    {
        public int Id { get; set; }
        public Guid GuidMail { get; set; }
		public string? Subject { get; set; }
        public string? Body { get; set; }
        public int SenderId { get; set; }
        public string SenderEmail { get; set; } = null!;
        public IList<string>? Recipients { get; set; }
		public DateTime SendAt { get; set; }
		// Navigation properties
		public virtual ICollection<FolderMail>? FolderMails { get; set; }
        public virtual ICollection<UserMail>? UserMails { get; set; }

    }
}
