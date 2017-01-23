using Order.Domain;
using System.Data.Entity;
using Order.Domain.DTOs;

namespace Order.Data
{
    public class OrderContext : DbContext
    {
        public OrderContext() : base("name=MarketContext")
        {

        }
        public DbSet<SalesOrder> Orders { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
            modelBuilder.Ignore<Customer>();
            modelBuilder.Ignore<CartItem>();
        }
    }
}
