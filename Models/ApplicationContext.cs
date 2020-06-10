using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace webapiInsurer.Models
{

    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts)
        {
        }
        public DbSet<Contracts> Contracts { get; set; }

     


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
            }
        }
    
}
