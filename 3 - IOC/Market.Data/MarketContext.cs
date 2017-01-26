using System.Data.Entity;
using Market.Domain;

namespace Market.Data
{
    public class MarketContext : DbContext
    {
        public MarketContext() : base("name=MarketContext")
        {
            Database.SetInitializer<MarketContext>(new InitializerToSeedDataForMarketContext());
        }
        public DbSet<Product> Products { get; set; } 
        public DbSet<Customer> Customers { get; set; }
    }
    public class OrderSystemContext : DbContext
    {
        public OrderSystemContext() : base("name=MarketContext")
        {
            Database.SetInitializer<MarketContext>(new InitializerToSeedDataForMarketContext());
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }

    
}