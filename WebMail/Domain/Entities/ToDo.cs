namespace WebMail.Domain.Entities
{
    public class ToDo : BaseEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Task { get; set; }
        public bool IsCompleted { get; set; } = false;
        public bool IsDeleted { get; set; } = false;
		// Navigation properties
		public virtual required User User { get; set; }
    }
}
