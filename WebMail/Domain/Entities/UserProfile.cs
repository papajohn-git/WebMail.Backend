namespace WebMail.Domain.Entities
{
    public class UserProfile : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string Address { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string ZipCode { get; set; } = null!;
        public int UserId { get; set; }

        // Navigation properties
        public virtual required User User { get; set; }
    }
}
