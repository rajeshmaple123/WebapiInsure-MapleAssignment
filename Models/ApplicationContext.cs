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
        public  DbSet<Insert_Contract_Post_Method_API> Inscon { get; set; }
        public DbSet<Update_Contract_PUT_Method_API> upcon { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        }
    
}
