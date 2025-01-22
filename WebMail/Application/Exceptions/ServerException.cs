﻿namespace WebMail.Application.Exceptions
{
	public class ServerException : AppException
	{
		public ServerException(string code, string message)
			: base(code, message)
		{
		}
	}
}
