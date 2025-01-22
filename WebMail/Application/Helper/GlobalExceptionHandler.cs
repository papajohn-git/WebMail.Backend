using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebMail.Application.Exceptions;

namespace WebMail.Application.Helper
{
	public class GlobalExceptionHandler
	{
		private readonly RequestDelegate _next;
		private readonly ILogger<GlobalExceptionHandler> _logger;

		private static readonly Dictionary<Type, int> ExceptionStatusCodes = new()
		{
			{ typeof(InvalidArgumentException), StatusCodes.Status400BadRequest },
			{ typeof(InvalidRegistrationException), StatusCodes.Status400BadRequest },
			{ typeof(EntityAlreadyExistsException), StatusCodes.Status400BadRequest },
			{ typeof(EntityForbiddenException), StatusCodes.Status403Forbidden },
			{ typeof(EntityNotAuthorizedException), StatusCodes.Status401Unauthorized },
			{ typeof(EntityNotFoundException), StatusCodes.Status404NotFound },
			{ typeof(ServerException), StatusCodes.Status500InternalServerError }

        };

		public GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
		{
			_next = next;
			_logger = logger;
		}

		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, ex.Message);

				var statusCode = ExceptionStatusCodes.ContainsKey(ex.GetType())
					? ExceptionStatusCodes[ex.GetType()]
					: StatusCodes.Status500InternalServerError;

				await ModifyHeader(context, ex.Message, statusCode);
			}
		}

		private static async Task ModifyHeader(HttpContext context, string message, int statusCode)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = statusCode;

			var problemDetails = new ProblemDetails
			{
				Title = "Error",
				Detail = message,
				Status = statusCode,
				Type = $"https://httpstatuses.com/{statusCode}",
				Instance = $"{context.Request.Method} {context.Request.Path}"
			};

			await context.Response.WriteAsync(JsonSerializer.Serialize(problemDetails));
		}
	}
}
