using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.TodoDTO;

namespace WebMail.Application.Services.Interfaces
{
	public interface ITodoService
	{
		Task<List<TodoReadOnlyDTO?>> GetTodosAsync(int userId);
		Task<Response> AddTodoAsync(CreateTodoDTO todo, int userId);
		Task<Response> CompleteTodoAsync(int todoId, int userId);
		Task<Response> DeleteTodoById(int todoId, int userId);
	}
}
