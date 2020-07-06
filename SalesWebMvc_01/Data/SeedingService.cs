using System;
using SalesWebMvc_01.Models;
using System.Linq;
using SalesWebMvc_01.Models.Enums;

namespace SalesWebMvc_01.Data
{
	public class SeedingService
	{
		private SalesWebMvc_01Context _context;

		public SeedingService(SalesWebMvc_01Context context)
		{
			_context = context;
		}

		public void Seed()
		{
			if (_context.Department.Any() ||
				_context.Seller.Any() ||
				_context.SalesRecord.Any())
			{
				return; //Banco de Dados Ja  Populado.
			}

			Department d1 = new Department(1, "Computers");
			Department d2 = new Department(2, "Electronics");
			Department d3 = new Department(3, "Fashion");
			Department d4 = new Department(4, "Books");

			Seller s1 = new Seller(1, "Bob", "bob@gmail.com", new DateTime(1998, 4, 21), 1000.0, d1);
			Seller s2 = new Seller(2, "Ana", "ana@gmail.com", new DateTime(1988, 5, 22), 1500.0, d2);
			Seller s3 = new Seller(3, "Marcos", "marcos@gmail.com", new DateTime(1999, 3, 11), 1200.0, d3);
			Seller s4 = new Seller(4, "Daniel", "daniel@gmail.com", new DateTime(1978, 8, 21), 900.0, d4);
			Seller s5 = new Seller(5, "Davi", "davi@gmail.com", new DateTime(1989, 4, 24), 1100.0, d4);
			Seller s6 = new Seller(6, "Samuel", "samuca@gmail.com", new DateTime(1999, 6, 08), 1550.0, d1);

			SalesRecord r1 = new SalesRecord(1, new DateTime(2018, 09, 21), 11000.0, SaleStatus.Billed, s1);
			SalesRecord r2 = new SalesRecord(2, new DateTime(2018, 09, 22), 5000.0, SaleStatus.Billed, s1);
			SalesRecord r3 = new SalesRecord(3, new DateTime(2018, 09, 23), 1000.0, SaleStatus.Billed, s2);
			SalesRecord r4 = new SalesRecord(4, new DateTime(2018, 09, 24), 9000.0, SaleStatus.Billed, s2);
			SalesRecord r5 = new SalesRecord(5, new DateTime(2018, 09, 25), 71000.0, SaleStatus.Billed, s3);
			SalesRecord r6 = new SalesRecord(6, new DateTime(2018, 09, 26), 91000.0, SaleStatus.Billed, s3);
			SalesRecord r7 = new SalesRecord(7, new DateTime(2018, 09, 27), 41000.0, SaleStatus.Billed, s4);
			SalesRecord r8 = new SalesRecord(8, new DateTime(2018, 09, 28), 31000.0, SaleStatus.Billed, s4);
			SalesRecord r9 = new SalesRecord(9, new DateTime(2018, 09, 29), 51000.0, SaleStatus.Billed, s5);
			SalesRecord r10 = new SalesRecord(10, new DateTime(2018, 09, 21), 51000.0, SaleStatus.Billed, s5);
			SalesRecord r11 = new SalesRecord(11, new DateTime(2018, 09, 22), 21000.0, SaleStatus.Billed, s6);
			SalesRecord r12 = new SalesRecord(12, new DateTime(2018, 09, 23), 31000.0, SaleStatus.Billed, s6);

			_context.Department.AddRange(d1, d2, d3, d4);

			_context.Seller.AddRange(s1, s2, s3, s4, s5, s6);

			_context.SalesRecord.AddRange(r1, r2, r3, r4, r5, r6, r7, r8, r9, r10, r11, r12);

			_context.SaveChanges();
		}
	}
}
