using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Models;

namespace Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(string connectionString) : base(connectionString)
        {
        }

        public CompanyDbContext() : base("name=Company")
        {

        }

        public DbSet<Product> Products { get; set; }

        public static DbContext CreateContext()
        {
            string connString = "name=Company"; //System.Configuration.ConfigurationManager.ConnectionStrings["Company"].ConnectionString;
            return new CompanyDbContext(connString);
        }
    }
}
