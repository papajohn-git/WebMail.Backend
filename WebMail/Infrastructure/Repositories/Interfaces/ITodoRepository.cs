using WebMail.Domain.Entities;

namespace WebMail.Infrastructure.Repositories.Interfaces
{
	public interface ITodoRepository
	{
		Task<List<ToDo>> GetTodosAsync(int userId);
		Task<ToDo?> GetTodoByUserIdAsync(int todoId, int userId);
	}
}
