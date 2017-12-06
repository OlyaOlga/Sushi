namespace SushiEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeOrderFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Sushi_Name", "dbo.SushiItems");
            DropIndex("dbo.Orders", new[] { "Sushi_Name" });
            AddColumn("dbo.Orders", "SushiName", c => c.String());
            AddColumn("dbo.Orders", "SushiPrice", c => c.Double(nullable: false));
            DropColumn("dbo.Orders", "Sushi_Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Sushi_Name", c => c.String(maxLength: 128));
            DropColumn("dbo.Orders", "SushiPrice");
            DropColumn("dbo.Orders", "SushiName");
            CreateIndex("dbo.Orders", "Sushi_Name");
            AddForeignKey("dbo.Orders", "Sushi_Name", "dbo.SushiItems", "Name");
        }
    }
}
