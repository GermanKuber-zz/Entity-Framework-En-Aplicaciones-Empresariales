using System.Data.Entity;
using Order.Read.Domain;

namespace Order.Read.Data
{

    public class OrderReadContext : DbContext
    {
        public OrderReadContext() : base("name=OrderContext")
        {

        }
        public DbSet<SalesOrder> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
        }
    }
}