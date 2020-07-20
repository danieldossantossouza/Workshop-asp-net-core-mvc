using SalesWebMvc_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc_01.Services
{
	public class SalesRecordService
	{
		private readonly SalesWebMvc_01Context _context;

		public SalesRecordService(SalesWebMvc_01Context contexte)
		{
			_context = contexte;
		}

		public async Task<List<SalesRecord>> FindByDateAsync(DateTime? minDate,DateTime?maxDate)
		{
			//Operação ascincrona que busca os registros de vendas por data.
			var result = from obj in _context.SalesRecord select obj;
			if (minDate.HasValue)
			{
				result = result.Where(x => x.Date >= minDate.Value);
			}
			if (maxDate.HasValue)
			{
				result = result.Where(x => x.Date <= maxDate.Value);
			}

			return await result
				.Include(x => x.Seller)
				.Include(x => x.Seller.Department)
				.OrderByDescending(x => x.Date)
				.ToListAsync();



		}
	}
}
