using Azure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Reflection;
using System.Reflection.Metadata;
using WebMail.Domain.Entities;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WebMail.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            Users = Set<User>();
            UserProfiles = Set<UserProfile>();
            Folders = Set<Folder>();
            Mails = Set<Mail>();
            UserMails = Set<UserMail>();
			FolderMails = Set<FolderMail>();
			ToDos = Set<ToDo>();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Folder> Folders { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<UserMail> UserMails { get; set; }
		public DbSet<FolderMail> FolderMails { get; set; }
		public DbSet<ToDo> ToDos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).HasColumnName("ID");
				entity.Property(e => e.Email).IsRequired();
                entity.Property(e => e.Password).IsRequired();
                entity.Property(e => e.ConfirmPassword).IsRequired();
                entity.Property(e => e.UserRole).HasMaxLength(255).HasConversion<string>().IsRequired();

                entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.Email).IsUnique();
                entity.HasIndex(e => e.UserRole);

                entity.HasOne(d => d.UserProfile)
                    .WithOne(p => p.User)
                    .HasForeignKey<UserProfile>(d => d.UserId)
                    .HasConstraintName("FK_UserProfiles_Users");

                entity.HasMany(d => d.ToDos)
                    .WithOne(p => p.User)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_ToDos_Users");

                entity.HasMany(d => d.Folders)
                    .WithOne(p => p.User)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Folders_Users")
					.OnDelete(DeleteBehavior.Cascade); //add this

				entity.HasMany(u => u.UserMails)
                    .WithOne(um => um.User)
                    .HasForeignKey(um => um.UserId)
					.OnDelete(DeleteBehavior.Cascade);
				//.OnDelete(DeleteBehavior.Restrict); remove this
			});

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfiles");
                entity.HasKey(e => e.Id);
				entity.Property(e => e.Id).HasColumnName("ID");
				entity.Property(e => e.FirstName).IsRequired();
                entity.Property(e => e.LastName).IsRequired();
                entity.Property(e => e.PhoneNumber).IsRequired();
                entity.Property(e => e.Address).IsRequired();
                entity.Property(e => e.City).IsRequired();
                entity.Property(e => e.State).IsRequired();
                entity.Property(e => e.ZipCode).IsRequired();
                entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.UserId).IsUnique();

			});

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.ToTable("ToDos");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.Task).IsRequired();
                entity.Property(e => e.IsCompleted).IsRequired();
                entity.Property(e => e.IsDeleted).IsRequired();

                entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.UserId);
            });

            modelBuilder.Entity<Folder>(entity =>
            {
                entity.ToTable("Folders");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.FolderName).IsRequired();

                entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.FolderName);
                entity.HasIndex(e => e.UserId);

				entity.HasOne(f => f.User)
	           .WithMany(u => u.Folders)
	           .HasForeignKey(f => f.UserId)
			   .OnDelete(DeleteBehavior.Cascade); //add this

			});

            modelBuilder.Entity<Mail>(entity =>
            {
                entity.ToTable("Mails");
                entity.HasKey(e => e.Id);

                entity.Property(e => e.SendAt).IsRequired();
				entity.Property(e => e.SenderId).IsRequired();
				entity.Property(e => e.SenderEmail).IsRequired();
                entity.Property(e => e.GuidMail).IsRequired();

				entity.Property(e => e.CreatedAt)
                    .ValueGeneratedOnAdd()
                    .HasDefaultValueSql("GETDATE()");

                entity.Property(e => e.UpdatedAt)
                    .ValueGeneratedOnAddOrUpdate()
                    .HasDefaultValueSql("GETDATE()");

                entity.HasIndex(e => e.GuidMail).IsUnique();
				entity.HasIndex(e => e.SenderId);
                entity.HasIndex(e => e.SendAt);
                entity.HasIndex(e => e.Subject);
                entity.HasIndex(e => e.SenderEmail);
				entity.HasIndex(e => e.Recipients);

				//entity.HasOne(m => m.Sender)
				//                .WithMany(u => u.SentMails)
				//                .HasForeignKey(m => m.SenderId)
				//                .OnDelete(DeleteBehavior.Restrict); remove this

				entity.HasMany(m => m.UserMails)
                    .WithOne(um => um.Mail)
                    .HasForeignKey(um => um.MailId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<UserMail>(entity =>
            {
                entity.HasKey(um => new { um.UserId, um.MailId });

                entity.Property(um => um.IsRead).IsRequired();
                entity.Property(um => um.ReceivedAt).IsRequired();

                entity.HasOne(um => um.User)
                      .WithMany(u => u.UserMails)
                      .HasForeignKey(um => um.UserId)
					  .OnDelete(DeleteBehavior.Cascade);
				//.OnDelete(DeleteBehavior.Restrict); remove this

				entity.HasOne(um => um.Mail)
                .WithMany(m => m.UserMails)
                .HasForeignKey(um => um.MailId)
                .OnDelete(DeleteBehavior.Restrict);
            });

			modelBuilder.Entity<FolderMail>(entity =>
			{
				entity.HasKey(um => new { um.FolderId, um.MailId });

				entity.HasOne(fm => fm.Folder)
			    .WithMany(f => f.FolderMails)
			    .HasForeignKey(fm => fm.FolderId)
				.OnDelete(DeleteBehavior.Cascade);
				//.OnDelete(DeleteBehavior.Restrict); remove this

				entity.HasOne(fm => fm.Mail)
			    .WithMany(m => m.FolderMails)
			    .HasForeignKey(fm => fm.MailId)
				.OnDelete(DeleteBehavior.Restrict);
			});

			//			Sure, here are the relationships for the User, UserProfile, ToDo, Folder, Mail, and UserMail entities:
			//User
			//•	UserProfile: One - to - One relationship.A User has one UserProfile, and a UserProfile belongs to one User.
			//•	ToDo: One - to - Many relationship.A User can have many ToDos, and a ToDo belongs to one User.
			//•	Folder: One - to - Many relationship.A User can have many Folders, and a Folder belongs to one User.
			//•	UserMail: One - to - Many relationship.A User can have many UserMails, and a UserMail belongs to one User.
			//UserProfile
			//•	User: One - to - One relationship.A UserProfile belongs to one User, and a User has one UserProfile.
			//ToDo
			//•	User: Many - to - One relationship.A ToDo belongs to one User, and a User can have many ToDos.
			//Folder
			//•	User: Many - to - One relationship.A Folder belongs to one User, and a User can have many Folders.
			//•	Mail: One - to - Many relationship.A Folder can have many Mails, and a Mail belongs to one Folder.
			//Mail
			//•	Folder: Many - to - One relationship.A Mail belongs to one Folder, and a Folder can have many Mails.
			//•	User(Sender): Many - to - One relationship.A Mail has one Sender(User), and a User can have many SentMails.
			//•	UserMail: One - to - Many relationship.A Mail can have many UserMails, and a UserMail belongs to one Mail.
			//UserMail
			//•	User: Many - to - One relationship.A UserMail belongs to one User, and a User can have many UserMails.
			//•	Mail: Many - to - One relationship.A UserMail belongs to one Mail, and a Mail can have many UserMails.

			//•	User and Mail: Many - to - Many via UserMail
			//•	User and UserProfile: One - to - One
			//•	User and ToDo: One - to - Many
			//•	User and Folder: One - to - Many
			//•	User and UserMail: One - to - Many
			//•	UserProfile and User: One - to - One
			//•	ToDo and User: Many - to - One
			//•	Folder and User: Many - to - One
			//•	Folder and Mail: One - to - Many
			//•	Mail and Folder: Many - to - One
			//•	Mail and User(Sender): Many - to - One
			//•	Mail and UserMail: One - to - Many
			//•	UserMail and User: Many - to - One
			//•	UserMail and Mail: Many - to - One
		}

        public override int SaveChanges()
        {
            UpdateTimestamps();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            UpdateTimestamps();
            return base.SaveChangesAsync(cancellationToken);
        }

        private void UpdateTimestamps()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is BaseEntity && (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in entries)
            {
                ((BaseEntity)entry.Entity).UpdatedAt = DateTime.UtcNow;

                if (entry.State == EntityState.Added)
                {
                    ((BaseEntity)entry.Entity).CreatedAt = DateTime.UtcNow;
                }
            }
        }
    }
}

