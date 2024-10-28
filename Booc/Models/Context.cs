using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Booc.Models
{
    public class Context : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publishers> publishers { get; set; }
        public DbSet<Bookstore> bookstore { get; set; }
        public DbSet<Genre> genres { get; set; }
        public DbSet<Trilogies> trilogies { get; set; }   
        public DbSet<Warehouse> warehouses { get; set; }


        public Context()
        {
            Database.Migrate();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string str = @"Server=(localdb)\MSSQLLocalDB;
                            Database=Books; 
                            Trusted_Connection=True;";
            optionsBuilder.UseSqlServer(str);
        }

    }
}
