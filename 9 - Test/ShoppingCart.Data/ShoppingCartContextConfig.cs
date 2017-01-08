using System.Data.Entity;

namespace ShoppingCart.Data
{
    public class ShoppingCartContextConfig : DbConfiguration
    {
        public ShoppingCartContextConfig()
        {
            this.SetDatabaseInitializer(new NullDatabaseInitializer<ShoppingCartContext>());
        }
    }
}