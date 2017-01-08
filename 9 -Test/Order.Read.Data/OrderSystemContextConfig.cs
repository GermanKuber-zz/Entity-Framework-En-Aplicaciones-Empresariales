using System.Data.Entity;

namespace Order.Read.Data
{
    public class OrderSystemContextConfig : DbConfiguration
    {
        public OrderSystemContextConfig()
        {
            SetDatabaseInitializer(new NullDatabaseInitializer<OrderReadContext>());
        }

    }
}
