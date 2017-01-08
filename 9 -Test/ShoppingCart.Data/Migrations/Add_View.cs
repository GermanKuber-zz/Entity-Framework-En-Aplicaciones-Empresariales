namespace ShoppingCart.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Add_View : DbMigration
    {
        public override void Up()
        {

            string script =
                              @"CREATE VIEW ShoppingCart.ProductListing
                                AS
                                SELECT ProductId, Description, P.Name, P.CategoryID,
                                C.Name as Category, MaxQuantity, CurrentPrice
                                FROM Maintenance.Products P
                                LEFT Join Maintenance.Categories C
                                ON P.CategoryId = C.CategoryId
                                WHERE p.IsAvailable = 1";
            ShoppingCartContext ctx = new ShoppingCartContext();
            ctx.Database.ExecuteSqlCommand(script);
        }

        public override void Down()
        {
        }
    }
}
