namespace Market.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                {
                    CustomerId = c.Int(nullable: false, identity: true),
                    FirstName = c.String(),
                    LastName = c.String(),
                    DateOfBirth = c.DateTime(nullable: false),
                    ContactDetail_Id = c.Int(),
                })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.ContactDetails", t => t.ContactDetail_Id)
                .Index(t => t.ContactDetail_Id);

            CreateTable(
                "dbo.Addresses",
                c => new
                {
                    AddressId = c.Int(nullable: false, identity: true),
                    Street = c.String(),
                    City = c.String(),
                    StateProvince = c.String(),
                    PostalCode = c.String(),
                    AddressType = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.AddressId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.ContactDetails",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    MobilePhone = c.String(),
                    HomePhone = c.String(),
                    OfficePhone = c.String(),
                    TwitterAlias = c.String(),
                    Facebook = c.String(),
                    LinkedIn = c.String(),
                    Skype = c.String(),
                    Messenger = c.String(),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Orders",
                c => new
                {
                    OrderId = c.Int(nullable: false, identity: true),
                    OrderDate = c.DateTime(nullable: false),
                    OrderSource = c.Int(nullable: false),
                    CustomerId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);

            CreateTable(
                "dbo.LineItems",
                c => new
                {
                    LineItemId = c.Int(nullable: false, identity: true),
                    Quantity = c.Int(nullable: false),
                    OrderId = c.Int(nullable: false),
                    ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.LineItemId)
                .ForeignKey("dbo.Orders", t => t.OrderId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.ProductId);

            CreateTable(
                "dbo.Products",
                c => new
                {
                    ProductId = c.Int(nullable: false, identity: true),
                    Description = c.String(),
                    Name = c.String(),
                    ProductionStart = c.DateTime(nullable: false),
                    IsAvailable = c.Boolean(nullable: false),
                })
                .PrimaryKey(t => t.ProductId);

            CreateTable(
                "dbo.Categories",
                c => new
                {
                    CategoryId = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                })
                .PrimaryKey(t => t.CategoryId);

            CreateTable(
                "dbo.CategoryProducts",
                c => new
                {
                    Category_CategoryId = c.Int(nullable: false),
                    Product_ProductId = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Category_CategoryId, t.Product_ProductId })
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.Product_ProductId, cascadeDelete: true)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.Product_ProductId);

        }

        public override void Down()
        {
            DropForeignKey("dbo.LineItems", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Product_ProductId", "dbo.Products");
            DropForeignKey("dbo.CategoryProducts", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.LineItems", "OrderId", "dbo.Orders");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "ContactDetail_Id", "dbo.ContactDetails");
            DropForeignKey("dbo.Addresses", "CustomerId", "dbo.Customers");
            DropIndex("dbo.CategoryProducts", new[] { "Product_ProductId" });
            DropIndex("dbo.CategoryProducts", new[] { "Category_CategoryId" });
            DropIndex("dbo.LineItems", new[] { "ProductId" });
            DropIndex("dbo.LineItems", new[] { "OrderId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            DropIndex("dbo.Addresses", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "ContactDetail_Id" });
            DropTable("dbo.CategoryProducts");
            DropTable("dbo.Categories");
            DropTable("dbo.Products");
            DropTable("dbo.LineItems");
            DropTable("dbo.Orders");
            DropTable("dbo.ContactDetails");
            DropTable("dbo.Addresses");
            DropTable("dbo.Customers");
        }
    }
}
