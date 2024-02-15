using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VorbereitungsProjektCampus02.Models
{
    internal class ProduktDBContextV3:DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
 
}
