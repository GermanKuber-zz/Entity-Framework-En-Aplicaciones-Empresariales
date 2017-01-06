namespace Market.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class New_Migration_Categoria : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products");
            DropIndex("dbo.CategoryProducts", new[] { "Category_CategoryId" });
            DropIndex("dbo.CategoryProducts", new[] { "Product_ProductId" });
            CreateTable(
                "dbo.CartItems",
                c => new
                {
                    CartItemId = c.Int(nullable: false, identity: true),
                    CartCookie = c.String(),
                    CartId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                    SelectedDateTime = c.DateTime(nullable: false),
                    CurrentPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                    Quantity = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.CartItemId)
                .ForeignKey("dbo.NewCarts", t => t.CartId, cascadeDelete: true)
                .Index(t => t.CartId);

            CreateTable(
                "dbo.NewCarts",
                c => new
                {
                    CartId = c.Int(nullable: false, identity: true),
                    CartCookie = c.String(),
                    Initialized = c.DateTime(nullable: false),
                    Expires = c.DateTime(nullable: false),
                    SourceUrl = c.String(),
                    CustomerId = c.Int(nullable: false),
                    CustomerCookie = c.String(),
                })
                .PrimaryKey(t => t.CartId);

            AddColumn("dbo.Customers", "CustomerCookie", c => c.String());
            AddColumn("dbo.Products", "CategoryId", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "Category_CategoryId", c => c.Int());
            AddColumn("dbo.Products", "Category_CategoryId1", c => c.Int());
            AddColumn("dbo.Categories", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.Products", "Category_CategoryId");
            CreateIndex("dbo.Products", "Category_CategoryId1");
            CreateIndex("dbo.Categories", "Product_ProductId");
            AddForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories", "CategoryId");
            AddForeignKey("dbo.Categories", "Product_ProductId", "dbo.Products", "ProductId");
            AddForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories", "CategoryId");
            DropTable("dbo.CategoryProducts");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.CategoryProducts",
                c => new
                {
                    Category_CategoryId = c.Int(nullable: false),
                    Product_ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Product_ProductId });

            DropForeignKey("dbo.Products", "Category_CategoryId1", "dbo.Categories");
            DropForeignKey("dbo.Categories", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.Products", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.CartItems", "CartId", "dbo.NewCarts");
            DropIndex("dbo.Categories", new[] { "Product_ProductId" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId1" });
            DropIndex("dbo.Products", new[] { "Category_CategoryId" });
            DropIndex("dbo.CartItems", new[] { "CartId" });
            DropColumn("dbo.Categories", "Product_ProductId");
            DropColumn("dbo.Products", "Category_CategoryId1");
            DropColumn("dbo.Products", "Category_CategoryId");
            DropColumn("dbo.Products", "CategoryId");
            DropColumn("dbo.Customers", "CustomerCookie");
            DropTable("dbo.NewCarts");
            DropTable("dbo.CartItems");
            CreateIndex("dbo.CategoryProducts", "Product_ProductId");
            CreateIndex("dbo.CategoryProducts", "Category_CategoryId");
            AddForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products", "ProductId", cascadeDelete: true);
            AddForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories", "CategoryId", cascadeDelete: true);
        }
    }
}
