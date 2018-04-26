namespace PROburgEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadeCityIDNullable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "CityID" });
            AlterColumn("dbo.Events", "CityID", c => c.Int());
            CreateIndex("dbo.Events", "CityID");
            AddForeignKey("dbo.Events", "CityID", "dbo.Cities", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropIndex("dbo.Events", new[] { "CityID" });
            AlterColumn("dbo.Events", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CityID");
            AddForeignKey("dbo.Events", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
        }
    }
}
