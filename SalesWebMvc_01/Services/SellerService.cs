using SalesWebMvc_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SalesWebMvc_01.Services.Exceptions;

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

		public void Upddate(Seller obj)
		{
			if(!_context.Seller.Any(x => x.Id == obj.Id))
			{
				throw new NotFoundException("Id não encontrado! ");
			}
			try
			{
				_context.Update(obj);
				_context.SaveChanges();
			}
			catch( DbUpdateConcurrencyException e)
			{
				throw new DbConcurrencyExeception(e.Message);
			}
		}
	}
}
