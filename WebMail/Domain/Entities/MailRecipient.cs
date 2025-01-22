namespace WebMail.Domain.Entities
{
    public class MailRecipient : BaseEntity
    {
        public int Id { get; set; }
        public int MailId { get; set; }
        public int ReceiverId { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime? ReadAt { get; set; }
        public DateTime ReceivedAt { get; set; }

        // Navigation property
        public virtual required Mail Mail { get; set; }
        public required User Receiver { get; set; }
    }
}