using WebMail.Domain.Enums.UserRole;

namespace WebMail.Domain.Entities
{
    public class User : BaseEntity
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string ConfirmPassword { get; set; } = null!;
        public UserRole UserRole { get; set; } = UserRole.User;

		// Navigation properties
		public virtual UserProfile? UserProfile { get; set; }
        public virtual ICollection<ToDo>? ToDos { get; set; }
        public virtual ICollection<Folder>? Folders { get; set; }
        public ICollection<UserMail>? UserMails { get; set; }

    }
}
