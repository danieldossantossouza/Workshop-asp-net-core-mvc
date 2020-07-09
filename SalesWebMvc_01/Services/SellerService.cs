using SalesWebMvc_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

		public void Insert(Seller obj)
		{			
			_context.Add(obj);
			_context.SaveChanges();
		}

		public Seller FindById(int id)
		{
			return _context.Seller.Include(obj=>obj.Department).FirstOrDefault(obj => obj.Id==id);
		}

		public void Remove(int id)
		{
			var obj = _context.Seller.Find(id);
			_context.Seller.Remove(obj);
			_context.SaveChanges();
		}
	}
}
