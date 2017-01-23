using System.Data.Entity;
using Order.Write.Domain;

namespace Order.Write.Data
{
    //TODO 02 - Creo contexto de Escritura
    public class OrderWriteContext : DbContext
    {
        public OrderWriteContext() : base("name=OrderContext")
        {
        }

        public DbSet<SalesOrder> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Order");
            //TODO 03 - Ignora la propiedad de navegación
            modelBuilder.Entity<SalesOrder>().Ignore(s => s.LineItems);
        }
    }
}