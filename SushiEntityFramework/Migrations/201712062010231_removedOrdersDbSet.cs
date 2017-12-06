namespace SushiEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedOrdersDbSet : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Orders");
        }
        
        public override void Down()
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
    }
}
