using System.Data.Entity;

namespace Maintenance.Data
{
    public class OrderSystemContextConfig : DbConfiguration
    {
        public OrderSystemContextConfig()
        {
            SetDatabaseInitializer(new InitializerToSeedDataForMarketContext());
        }

    }
}