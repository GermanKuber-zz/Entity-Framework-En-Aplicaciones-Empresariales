using System.Data.Entity;

namespace ShoppingCart.Data
{
    public class ReferenceContext : DbContext
    {
        //TODO : 06 - Agrego Contexto de referencia
        public ReferenceContext() : base("name=MarketContext")
        {
        }

        public DbSet<Domain.Customer> Customers { get; set; }
        public DbSet<Domain.Product> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ShoppingCart");
            modelBuilder.Entity<Domain.Product>().ToTable("ProductListing", "ShoppingCart");
            base.OnModelCreating(modelBuilder);
        }
    }
}