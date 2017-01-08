using System.Data.Entity;

namespace Order.Data
{
    public class OrderSystemContextConfig : DbConfiguration
    {
        public OrderSystemContextConfig()
        {
            SetDatabaseInitializer(new NullDatabaseInitializer<OrderContext>());
        }

    }
}