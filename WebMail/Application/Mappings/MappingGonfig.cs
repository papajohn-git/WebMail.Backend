using AutoMapper;
using WebMail.Application.DTOs.Folder;
using WebMail.Application.DTOs.MailDTO;
using WebMail.Application.DTOs.TodoDTO;
using WebMail.Application.DTOs.User;
using WebMail.Application.DTOs.UserProfile;

using WebMail.Domain.Entities;

namespace WebMail.Application.Mappings
{
	public class MappingGonfig : Profile
	{
		public MappingGonfig()
		{
			//User Mapper
			CreateMap<User, UserReadOnlyDTO>().ReverseMap();
			CreateMap<User, UserSignUpDTO>().ReverseMap();
			CreateMap<User, UserEmailFullNameDTO>()
				.ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
				.ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.UserProfile!.FirstName} {src.UserProfile!.LastName}"))
				.ReverseMap();

			//User UserProfile Mapper
			CreateMap<UserProfile, UserProfileReadOnlyDTO>().ReverseMap();
			CreateMap<UserProfile, UserProfilePatchDTO>().ReverseMap();
			CreateMap<User, SupervisorUsersUpdateDTO>().ReverseMap();
			CreateMap<UserProfile, SupervisorUsersUpdateDTO>().ReverseMap();
			CreateMap<User, SupervisorUsersDetailsReadOnlyDTO>()
				.ForMember(dest => dest.UserProfileCreatedAt, opt => opt.MapFrom(src => src.UserProfile!.CreatedAt))
				.ForMember(dest => dest.UserProfileUpdatedAt, opt => opt.MapFrom(src => src.UserProfile!.UpdatedAt))
				.ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.UserProfile!.FirstName))
				.ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.UserProfile!.LastName))
				.ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.UserProfile!.PhoneNumber))
				.ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.UserProfile!.Address))
				.ForMember(dest => dest.City, opt => opt.MapFrom(src => src.UserProfile!.City))
				.ForMember(dest => dest.State, opt => opt.MapFrom(src => src.UserProfile!.State))
				.ForMember(dest => dest.ZipCode, opt => opt.MapFrom(src => src.UserProfile!.ZipCode))
				.ForMember(dest => dest.UserCreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
				.ForMember(dest => dest.UserUpdatedAt, opt => opt.MapFrom(src => src.UpdatedAt))
				.ReverseMap();
			CreateMap<User, SupervisorUsersListReadOnlyDTO>()
				.ForMember(dest => dest.UserCreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
				.ReverseMap();

			//User Folder Mapper
			CreateMap<Folder, FolderReadOnlyDTO>().ReverseMap();

			//Mail Mapper
			CreateMap<UserMail, MailReadOnlyDTO>()
				.ForMember(dest => dest.Subject, opt => opt.MapFrom(src => $"{src.Mail!.Subject}"))
				.ForMember(dest => dest.Body, opt => opt.MapFrom(src => $"{src.Mail!.Body}"))
				//.ForMember(dest => dest.SenderEmail, opt => opt.MapFrom(src => $"{src.Mail!.Sender!.Email}"))
				.ForMember(dest => dest.SenderEmail, opt => opt.MapFrom(src => $"{src.Mail!.SenderEmail}"))
				.ForMember(dest => dest.Recipients, opt => opt.MapFrom(src => src.Mail!.Recipients))
				.ForMember(dest => dest.SendAt, opt => opt.MapFrom(src => src.Mail!.SendAt))
				.ReverseMap();

			CreateMap<Mail, MailReadOnlyDTO>().ReverseMap();
			//.ForMember(dest => dest.IsRead, opt => opt.MapFrom(src => src.UserMails!.First().IsRead))
			//.ForMember(dest => dest.ReceivedAt, opt => opt.MapFrom(src => src.UserMails!.First().ReceivedAt))
			////.ForMember(dest => dest.ReadAt, opt => opt.MapFrom(src => src.UserMails!.FirstOrDefault() != null ? src.UserMails!.FirstOrDefault()!.ReadAt : (DateTime?)null))
			////.ForMember(dest => dest.ReadAt, opt => opt.MapFrom(src => src.UserMails!.First().ReadAt ?? (DateTime?)null))
			//.ForMember(dest => dest.ReadAt, opt => opt.MapFrom(src => src.UserMails!.First().ReadAt.HasValue ? src.UserMails!.First().ReadAt : (DateTime?)null))
			//.ReverseMap();

			//Todo Mapper
			CreateMap<ToDo, TodoReadOnlyDTO>().ReverseMap();
			CreateMap<ToDo, CreateTodoDTO>().ReverseMap();

		}
	}
}
