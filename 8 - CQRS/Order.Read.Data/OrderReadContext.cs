using System.Data.Entity;
using Order.Read.Domain;

namespace Order.Read.Data
{
    //TODO 01 - Creo contexto de Lectura
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