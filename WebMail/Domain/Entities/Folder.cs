namespace WebMail.Domain.Entities
{
    public class Folder : BaseEntity
    {
        public int Id { get; set; }
        public string FolderName { get; set; } = null!;
        public int UserId { get; set; }
        public virtual required User User { get; set; } = null!;
		//public virtual ICollection<Mail>? Emails { get; set; }
		public virtual ICollection<FolderMail>? FolderMails { get; set; }


	}
}
