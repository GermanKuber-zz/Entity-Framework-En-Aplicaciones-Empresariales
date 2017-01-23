using System.Data.Entity;

namespace ShoppingCart.Data
{
    public class ShoppingCartContextConfig : DbConfiguration
    {
        public ShoppingCartContextConfig()
        {
            SetDatabaseInitializer(new NullDatabaseInitializer<ShoppingCartContext>());
        }
    }
}