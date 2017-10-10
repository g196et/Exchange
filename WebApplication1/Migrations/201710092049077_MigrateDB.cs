namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        count = c.Int(nullable: false),
                        email = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Sellers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        price = c.Single(nullable: false),
                        count = c.Int(nullable: false),
                        email = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.Orders", "customer_ID", c => c.Int());
            AddColumn("dbo.Orders", "seller_ID", c => c.Int());
            CreateIndex("dbo.Orders", "customer_ID");
            CreateIndex("dbo.Orders", "seller_ID");
            AddForeignKey("dbo.Orders", "customer_ID", "dbo.Customers", "ID");
            AddForeignKey("dbo.Orders", "seller_ID", "dbo.Sellers", "ID");
            DropColumn("dbo.Orders", "dateOfComplete");
            DropColumn("dbo.Orders", "dateOfBuy");
            DropColumn("dbo.Orders", "dateOfSell");
            DropColumn("dbo.Orders", "price");
            DropColumn("dbo.Orders", "count");
            DropColumn("dbo.Orders", "emailCustomer");
            DropColumn("dbo.Orders", "emailSeller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "emailSeller", c => c.String());
            AddColumn("dbo.Orders", "emailCustomer", c => c.String());
            AddColumn("dbo.Orders", "count", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "price", c => c.Single(nullable: false));
            AddColumn("dbo.Orders", "dateOfSell", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "dateOfBuy", c => c.DateTime(nullable: false));
            AddColumn("dbo.Orders", "dateOfComplete", c => c.DateTime(nullable: false));
            DropForeignKey("dbo.Orders", "seller_ID", "dbo.Sellers");
            DropForeignKey("dbo.Orders", "customer_ID", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "seller_ID" });
            DropIndex("dbo.Orders", new[] { "customer_ID" });
            DropColumn("dbo.Orders", "seller_ID");
            DropColumn("dbo.Orders", "customer_ID");
            DropTable("dbo.Sellers");
            DropTable("dbo.Customers");
        }
    }
}
