namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        dateOfComplete = c.DateTime(nullable: false),
                        dateOfBuy = c.DateTime(nullable: false),
                        dateOfSell = c.DateTime(nullable: false),
                        price = c.Single(nullable: false),
                        count = c.Int(nullable: false),
                        emailCustomer = c.String(),
                        emailSeller = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
