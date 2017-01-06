using System.Data.Entity;
using Maintenance.Domain;

namespace Maintenance.Data
{
    public class MaintenanceContext : DbContext
    {

        public MaintenanceContext() : base("name=MarketContext")
        {
            Database.Initialize(true);
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Maintenance");
            base.OnModelCreating(modelBuilder);
        }
    }
}