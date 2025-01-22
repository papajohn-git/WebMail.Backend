using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class UserMailRepository : GenericRepository<UserMail>, IUserMailRepository
	{
		public UserMailRepository(AppDbContext context) : base(context)
		{

		}
	}
}
