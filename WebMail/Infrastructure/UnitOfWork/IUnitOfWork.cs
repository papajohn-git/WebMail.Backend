using WebMail.Infrastructure.Repositories.Implementations;

namespace WebMail.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        UserRepository UserRepository { get; }
		FolderRepository FolderRepository { get; }
		UserProfileRepository UserProfileRepository { get; }
		MailRepository MailRepository { get; }
		UserMailRepository UserMailRepository { get; }
		FolderMailRepository FolderMailRepository { get; }
		TodoRepository TodoRepository { get; }

		Task<bool> SaveAsync();
    }
}
