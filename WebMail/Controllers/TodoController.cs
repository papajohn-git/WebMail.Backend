using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebMail.Application.DTOs.TodoDTO;
using WebMail.Application.Exceptions;
using WebMail.Application.Services.Interfaces;

namespace WebMail.Controllers
{
	public class TodoController : BaseController
	{
		private readonly IConfiguration _configuration;

		public TodoController(IApplicationService applicationService, IConfiguration configuration) : base(applicationService)
		{
			_configuration = configuration;
		}

		[HttpGet]
		[Authorize]
		public async Task<IActionResult> GetTodos()
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.TodoService.GetTodosAsync(userId);

			return Ok(result);
		}

		[HttpPost]
		[Authorize]
		public async Task<IActionResult> AddTodo([FromBody] CreateTodoDTO task)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.TodoService.AddTodoAsync(task, userId);

			return result.Success ? Ok(result) : BadRequest(result);
		}

		[HttpPut("{todoId}")]
		[Authorize]
		public async Task<IActionResult> CompleteTodo(int todoId)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.TodoService.CompleteTodoAsync(todoId, userId);

			return Ok(result);
		}

		[HttpDelete("{todoId}")]
		[Authorize]
		public async Task<IActionResult> DeleteTodo(int todoId)
		{
			var userId = AppUser!.Id ?? throw new EntityForbiddenException("", "User is not authenticated.");

			var result = await _applicationService.TodoService.DeleteTodoById(todoId, userId);

			return Ok(result);
		}
	}
}
