namespace WebMail.Domain.Entities
{
    public class UserMail
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int MailId { get; set; }
        public bool IsDeleted { get; set; } = false;
        public bool IsRead { get; set; } = false;
        public DateTime ReceivedAt { get; set; }
        public DateTime? ReadAt { get; set; }

        // Navigation properties
        public virtual User? User { get; set; }
        public virtual Mail? Mail { get; set; }
    }
}
