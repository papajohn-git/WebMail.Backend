using System.ComponentModel.DataAnnotations;

namespace WebMail.Application.DTOs.TodoDTO
{
	public class CreateTodoDTO
	{
		[Required]
		[StringLength(100, MinimumLength = 2, ErrorMessage = "Task should be between 2 and 100 characters.")]
		public string? Task { get; set; }
	}
}
