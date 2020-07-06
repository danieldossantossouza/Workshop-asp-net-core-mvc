using SalesWebMvc_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc_01.Services
{
	public class SellerService
	{
		private readonly SalesWebMvc_01Context _context;

		public SellerService(SalesWebMvc_01Context contexte)
		{
			_context = contexte;
		}


		public List<Seller> FindAll()
		{

			return _context.Seller.ToList(); //Operação Síncrona

		}

	}
}
