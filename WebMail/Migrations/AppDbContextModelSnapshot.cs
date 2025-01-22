﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebMail.Infrastructure.Data;

#nullable disable

namespace WebMail.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("WebMail.Domain.Entities.Folder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FolderName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FolderName");

                    b.HasIndex("UserId");

                    b.ToTable("Folders", (string)null);
                });

            modelBuilder.Entity("WebMail.Domain.Entities.FolderMail", b =>
                {
                    b.Property<int>("FolderId")
                        .HasColumnType("int");

                    b.Property<int>("MailId")
                        .HasColumnType("int");

                    b.HasKey("FolderId", "MailId");

                    b.HasIndex("MailId");

                    b.ToTable("FolderMails");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.Mail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Body")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<Guid>("GuidMail")
                        .HasColumnType("uniqueidentifier");

                    b.PrimitiveCollection<string>("Recipients")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("SendAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("SenderEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("SenderId")
                        .HasColumnType("int");

                    b.Property<string>("Subject")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("Id");

                    b.HasIndex("GuidMail")
                        .IsUnique();

                    b.HasIndex("Recipients");

                    b.HasIndex("SendAt");

                    b.HasIndex("SenderEmail");

                    b.HasIndex("SenderId");

                    b.HasIndex("Subject");

                    b.ToTable("Mails", (string)null);
                });

            modelBuilder.Entity("WebMail.Domain.Entities.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ToDos", (string)null);
                });

            modelBuilder.Entity("WebMail.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ConfirmPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .ValueGeneratedOnAddOrUpdate()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("UserRole")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserRole");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("WebMail.Domain.Entities.UserMail", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("MailId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsRead")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ReadAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ReceivedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("UserId", "MailId");

                    b.HasIndex("MailId");

                    b.ToTable("UserMails");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.UserProfile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserProfiles", (string)null);
                });

            modelBuilder.Entity("WebMail.Domain.Entities.Folder", b =>
                {
                    b.HasOne("WebMail.Domain.Entities.User", "User")
                        .WithMany("Folders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Folders_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.FolderMail", b =>
                {
                    b.HasOne("WebMail.Domain.Entities.Folder", "Folder")
                        .WithMany("FolderMails")
                        .HasForeignKey("FolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebMail.Domain.Entities.Mail", "Mail")
                        .WithMany("FolderMails")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Folder");

                    b.Navigation("Mail");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.ToDo", b =>
                {
                    b.HasOne("WebMail.Domain.Entities.User", "User")
                        .WithMany("ToDos")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_ToDos_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.UserMail", b =>
                {
                    b.HasOne("WebMail.Domain.Entities.Mail", "Mail")
                        .WithMany("UserMails")
                        .HasForeignKey("MailId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("WebMail.Domain.Entities.User", "User")
                        .WithMany("UserMails")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Mail");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.UserProfile", b =>
                {
                    b.HasOne("WebMail.Domain.Entities.User", "User")
                        .WithOne("UserProfile")
                        .HasForeignKey("WebMail.Domain.Entities.UserProfile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_UserProfiles_Users");

                    b.Navigation("User");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.Folder", b =>
                {
                    b.Navigation("FolderMails");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.Mail", b =>
                {
                    b.Navigation("FolderMails");

                    b.Navigation("UserMails");
                });

            modelBuilder.Entity("WebMail.Domain.Entities.User", b =>
                {
                    b.Navigation("Folders");

                    b.Navigation("ToDos");

                    b.Navigation("UserMails");

                    b.Navigation("UserProfile");
                });
#pragma warning restore 612, 618
        }
    }
}
