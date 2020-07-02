using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SalesWebMvc_01.Models
{
    public class SalesWebMvc_01Context : DbContext
    {
        public SalesWebMvc_01Context (DbContextOptions<SalesWebMvc_01Context> options)
            : base(options)
        {
        }

        public DbSet<SalesWebMvc_01.Models.Department> Department { get; set; }
    }
}
