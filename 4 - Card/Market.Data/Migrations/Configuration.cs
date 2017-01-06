namespace Market.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Market.Data.MarketContext>
    {

        public Configuration()
        {
            AutomaticMigrationsEnabled = false;

            ContextKey = "Market.Data.MarketContext";
        }


    }
}
