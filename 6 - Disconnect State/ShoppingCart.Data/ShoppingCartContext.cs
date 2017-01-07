using System.Data.Entity;
using Market.Core.Interfaces;
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
            //TODO 6 - Ignoro el estado para que no se guarde en la DB
            modelBuilder.Types<IStateObject>().Configure(c => c.Ignore(p => p.State));
            base.OnModelCreating(modelBuilder);
        }
    }
}