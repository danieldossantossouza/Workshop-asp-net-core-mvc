using Microsoft.EntityFrameworkCore;
using SalesWebMvc_01.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc_01.Services
{
	public class DepartmentService
	{
		private readonly SalesWebMvc_01Context _context;

		public DepartmentService(SalesWebMvc_01Context contexte)
		{
			_context = contexte;
		}

		public async Task<List<Department>> FindAllAsync()
		{
			return  await _context.Department.OrderBy(x => x.Name).ToListAsync();//Operação Asíncrona
		}
	}
}
