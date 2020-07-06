using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWebMvc_01.Models.ViewModels
{
	public class SellerFormViewModel
	{
		public Seller Seller { get; set; }

		public ICollection<Department> Departments { get; set; }
	}
}
