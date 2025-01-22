using Microsoft.EntityFrameworkCore;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.Data;
using WebMail.Infrastructure.Repositories.Interfaces;

namespace WebMail.Infrastructure.Repositories.Implementations
{
	public class TodoRepository : GenericRepository<ToDo>, ITodoRepository
	{
		public TodoRepository(AppDbContext context) : base(context)
		{

		}

		public async Task<List<ToDo>> GetTodosAsync(int userId)
		{ 
			var todos =	await context.ToDos
				.Where(t => t.UserId == userId)
				.ToListAsync();

			return todos;
		}

		public async Task<ToDo?> GetTodoByUserIdAsync(int todoId, int userId)
		{
			return await context.ToDos
				.FirstOrDefaultAsync(t => t.UserId == userId && t.Id == todoId);
		}

	}
}
