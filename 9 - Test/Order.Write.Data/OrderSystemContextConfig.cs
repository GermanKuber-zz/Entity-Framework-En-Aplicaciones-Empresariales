using System.Data.Entity;

namespace Order.Write.Data
{
    public class OrderSystemContextConfig : DbConfiguration
    {
        public OrderSystemContextConfig()
        {
            SetDatabaseInitializer(new NullDatabaseInitializer<OrderWriteContext>());
        }
    }
}