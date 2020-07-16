using System;


namespace SalesWebMvc_01.Services.Exceptions
{
	public class IntegrityException: ApplicationException
	{
		public IntegrityException(string message) : base(message)
		{
		}
	}
}
