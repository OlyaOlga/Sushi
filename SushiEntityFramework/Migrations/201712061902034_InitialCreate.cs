namespace SushiEntityFramework.Migrations
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
                        OrderId = c.Int(nullable: false, identity: true),
                        Sushi_Name = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.SushiItems", t => t.Sushi_Name)
                .Index(t => t.Sushi_Name);
            
            CreateTable(
                "dbo.SushiItems",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Name);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Sushi_Name", "dbo.SushiItems");
            DropIndex("dbo.Orders", new[] { "Sushi_Name" });
            DropTable("dbo.SushiItems");
            DropTable("dbo.Orders");
        }
    }
}
