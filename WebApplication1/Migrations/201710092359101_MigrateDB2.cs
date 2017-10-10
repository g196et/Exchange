namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "customer_ID", "dbo.Customers");
            DropForeignKey("dbo.Orders", "seller_ID", "dbo.Sellers");
            DropIndex("dbo.Orders", new[] { "customer_ID" });
            DropIndex("dbo.Orders", new[] { "seller_ID" });
            AddColumn("dbo.Orders", "dateComplete", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "dateCustomer", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "dateSeller", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "price", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "EmailCustomer", c => c.Int(nullable: false));
            AddColumn("dbo.Orders", "EmailSeller", c => c.Int(nullable: false));
            DropColumn("dbo.Orders", "customer_ID");
            DropColumn("dbo.Orders", "seller_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "seller_ID", c => c.Int());
            AddColumn("dbo.Orders", "customer_ID", c => c.Int());
            DropColumn("dbo.Orders", "EmailSeller");
            DropColumn("dbo.Orders", "EmailCustomer");
            DropColumn("dbo.Orders", "price");
            DropColumn("dbo.Orders", "dateSeller");
            DropColumn("dbo.Orders", "dateCustomer");
            DropColumn("dbo.Orders", "dateComplete");
            CreateIndex("dbo.Orders", "seller_ID");
            CreateIndex("dbo.Orders", "customer_ID");
            AddForeignKey("dbo.Orders", "seller_ID", "dbo.Sellers", "ID");
            AddForeignKey("dbo.Orders", "customer_ID", "dbo.Customers", "ID");
        }
    }
}
