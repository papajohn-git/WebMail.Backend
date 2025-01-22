namespace WebMail.Application.DTOs.TodoDTO
{
	public class TodoReadOnlyDTO
	{
		public int Id { get; set; }
		public string? Task { get; set; }
		public bool IsCompleted { get; set; }
	}
}
