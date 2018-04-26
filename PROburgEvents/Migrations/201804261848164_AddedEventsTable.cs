namespace PROburgEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEventsTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Tagline = c.String(),
                        Description = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        ZIP = c.String(),
                        AgeLimit = c.Int(),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Events");
        }
    }
}
