using System;


namespace SalesWebMvc_01.Services.Exceptions
{
	public class NotFoundException :ApplicationException
	{
		public NotFoundException(string message):base (message)
		{
		}
	}
}
