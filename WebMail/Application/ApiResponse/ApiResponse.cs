namespace WebMail.Application.ApiResponse
{
	public record Response(bool Success = false, string? Message = null);
}
