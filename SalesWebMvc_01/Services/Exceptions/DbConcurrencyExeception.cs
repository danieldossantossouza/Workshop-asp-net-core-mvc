using System;


namespace SalesWebMvc_01.Services.Exceptions
{
	public class DbConcurrencyExeception :ApplicationException
	{
		public DbConcurrencyExeception(string message):base(message)
		{
		}
	}
}
