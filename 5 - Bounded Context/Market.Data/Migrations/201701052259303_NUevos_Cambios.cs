namespace Market.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NUevos_Cambios : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Products", "MaxQuantity", c => c.Int(nullable: false));
            AddColumn("dbo.Products", "CurrentPrice", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Products", "CurrentPrice");
            DropColumn("dbo.Products", "MaxQuantity");
        }
    }
}
