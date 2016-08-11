using CrunchyGranola2.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CrunchyGranola2.DAL
{
    public class CrunchyGranola2Context : DbContext
    {
        public CrunchyGranola2Context() : base("CrunchyGranola2Context")
        {

        }

        public DbSet<Customer>Customers { get; set; }
        public DbSet<Purchase>Purchases { get; set; }
        public DbSet<Product>Products { get; set; }
        public DbSet<Department>Departments { get; set; }
        public DbSet<Employee>Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}