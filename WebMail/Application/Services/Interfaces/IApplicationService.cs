using WebMail.Application.Services.Implementations;

namespace WebMail.Application.Services.Interfaces
{
	public interface IApplicationService
	{
		UserService UserService { get; }
		UserProfileService UserProfileService { get; }
		FolderService FolderService { get; }
		MailService MailService { get; }
		TodoService TodoService { get; }
	}
}
