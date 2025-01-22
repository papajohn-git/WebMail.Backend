using AutoMapper;
using WebMail.Application.Services.Interfaces;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class ApplicationService : IApplicationService
	{
		protected readonly IUnitOfWork _unitOfWork;
		private readonly IMapper _mapper;

		public ApplicationService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_mapper = mapper;
		}
		public UserService UserService => new UserService(_unitOfWork, _mapper);
		public UserProfileService UserProfileService => new UserProfileService(_unitOfWork, _mapper);
		public FolderService FolderService => new FolderService(_unitOfWork, _mapper);
		public MailService MailService => new MailService(_unitOfWork, _mapper);
		public TodoService TodoService => new TodoService(_unitOfWork, _mapper);
	}
}
