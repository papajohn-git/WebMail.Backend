﻿namespace WebMail.Application.Exceptions
{
	public class InvalidRegistrationException : Exception
	{
		public InvalidRegistrationException(string s)
			: base(s)
		{
		}
	}
}
