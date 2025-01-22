using AutoMapper;
using Serilog;
using WebMail.Application.ApiResponse;
using WebMail.Application.DTOs.TodoDTO;
using WebMail.Application.Services.Interfaces;
using WebMail.Domain.Entities;
using WebMail.Infrastructure.UnitOfWork;

namespace WebMail.Application.Services.Implementations
{
	public class TodoService : ITodoService
	{
		private readonly IUnitOfWork _unitOfWork;
		private readonly ILogger<TodoService> _logger;
		private readonly IMapper _mapper;

		public TodoService(IUnitOfWork unitOfWork, IMapper mapper)
		{
			_unitOfWork = unitOfWork;
			_logger = new LoggerFactory().AddSerilog().CreateLogger<TodoService>();
			_mapper = mapper;
		}

		public async Task<List<TodoReadOnlyDTO?>> GetTodosAsync(int userId)
		{
			var todos = await _unitOfWork.TodoRepository.GetTodosAsync(userId);
			var todosDTO = _mapper.Map<List<TodoReadOnlyDTO?>>(todos);

			return todosDTO;

		}

		public async Task<Response> AddTodoAsync(CreateTodoDTO todo, int userId)
		{
			try
			{
				var userExist = await _unitOfWork.UserRepository.GetUserByIdAsync(userId) ?? throw new Exception("User not found.");

				var newTodo = new ToDo
				{
					User = userExist,
					Task = todo.Task,
					IsCompleted = false,
					UserId = userId
				};
				

				await _unitOfWork.TodoRepository.AddAsync(newTodo);
				var result = await _unitOfWork.SaveAsync();

				return new Response { Success = result, Message = "Todo added successfully." };
			}
			catch
			{
				_logger.LogError("Todo failed to be added.");
				return new Response { Success = false, Message = "Todo faild to be added." };

			}
		}

		public async Task<Response> CompleteTodoAsync(int todoId, int userId)
		{
			var userExist = await _unitOfWork.UserRepository.GetUserByIdAsync(userId) ?? throw new Exception("User not found.");
			try
			{
				var todo = await _unitOfWork.TodoRepository.GetTodoByUserIdAsync(todoId, userExist.Id);

				if (todo == null)
				{
					throw new Exception("Todo not found.");
				}

				if (todo.UserId != userId)
				{
					return new Response { Success = false, Message = "You are not authorized to complete this todo." };
				}

				todo.IsCompleted = true;

				await _unitOfWork.TodoRepository.UpdateAsync(todo);
				var result = await _unitOfWork.SaveAsync();

				return new Response { Success = result, Message = "Todo completed successfully." };
			}
			catch
			{
				_logger.LogError("Todo failed to be completed.");
				return new Response { Success = false, Message = "Todo faild to be completed " };
			}
			
		}

		public async Task<Response> DeleteTodoById(int todoId,int userId)
		{
			try
			{
				var userExist = await _unitOfWork.UserRepository.GetUserByIdAsync(userId) ?? throw new Exception("User not found.");

				var todo = await _unitOfWork.TodoRepository.GetTodoByUserIdAsync(todoId, userExist.Id);

				if (todo == null)
				{
					throw new Exception("Todo not found.");
				}

				if (todo.UserId != userId)
				{
					return new Response { Success = false, Message = "You are not authorized to complete this todo." };
				}

				await _unitOfWork.TodoRepository.DeleteAsync(todo.Id);
				var result = await _unitOfWork.SaveAsync();
				return new Response { Success = result, Message = "Todo deleted successfully." };
			}
			catch
			{
				_logger.LogError("Todo failed to be deleted.");
				return new Response { Success = false, Message = "Todo faild to be deleted." };
			}
		}



	}
}
 