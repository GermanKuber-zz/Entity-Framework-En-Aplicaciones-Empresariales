using System.Data.Entity;
using Market.Domain;

namespace Market.Data
{
    public class MarketContext : DbContext
    {

        //TODO : 3 -  Agrego nuevas clases al Contexto
        public MarketContext() : base("name=MarketContext")
        {
            Database.SetInitializer<MarketContext>(new InitializerToSeedDataForMarketContext());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<NewCart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NewCart>().HasKey(c => c.CartId);
            modelBuilder.Ignore<RevisitedCart>();
            base.OnModelCreating(modelBuilder);
        }
    }

    public class OrderSystemContextConfig : DbConfiguration
    {
        public OrderSystemContextConfig()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<MarketContext>());
        }

    }
}