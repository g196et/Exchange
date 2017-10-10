namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MigrateDB3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "dateComplete", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "dateCustomer", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "dateSeller", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Orders", "price", c => c.Single(nullable: false));
            AlterColumn("dbo.Orders", "EmailCustomer", c => c.String());
            AlterColumn("dbo.Orders", "EmailSeller", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Orders", "EmailSeller", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "EmailCustomer", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "price", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "dateSeller", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "dateCustomer", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "dateComplete", c => c.Int(nullable: false));
        }
    }
}
