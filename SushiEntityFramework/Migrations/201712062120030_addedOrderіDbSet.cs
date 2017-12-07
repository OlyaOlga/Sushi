namespace SushiEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedOrderіDbSet : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        SushiName = c.String(),
                        SushiPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Orders");
        }
    }
}
