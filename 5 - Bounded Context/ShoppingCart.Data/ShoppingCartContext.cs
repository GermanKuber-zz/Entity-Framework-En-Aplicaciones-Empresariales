using System.Data.Entity;
using ShoppingCart.Domain;

namespace ShoppingCart.Data
{
    public class ShoppingCartContext : DbContext
    {
        public ShoppingCartContext() : base("name=MarketContext")
        {
        }

        public DbSet<NewCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("ShoppingCart");
            modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
            modelBuilder.Ignore<RevisitedCart>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ShoppingCartContextConfig : DbConfiguration
    {
        public ShoppingCartContextConfig()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<ShoppingCartContext>());
        }
    }
}