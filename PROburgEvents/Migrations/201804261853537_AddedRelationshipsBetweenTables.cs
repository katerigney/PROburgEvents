namespace PROburgEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedRelationshipsBetweenTables : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EventAttendees",
                c => new
                    {
                        Event_ID = c.Int(nullable: false),
                        Attendee_ID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Event_ID, t.Attendee_ID })
                .ForeignKey("dbo.Events", t => t.Event_ID, cascadeDelete: true)
                .ForeignKey("dbo.Attendees", t => t.Attendee_ID, cascadeDelete: true)
                .Index(t => t.Event_ID)
                .Index(t => t.Attendee_ID);
            
            AddColumn("dbo.Events", "CityID", c => c.Int(nullable: false));
            CreateIndex("dbo.Events", "CityID");
            AddForeignKey("dbo.Events", "CityID", "dbo.Cities", "ID", cascadeDelete: true);
            DropColumn("dbo.Events", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Events", "City", c => c.String());
            DropForeignKey("dbo.Events", "CityID", "dbo.Cities");
            DropForeignKey("dbo.EventAttendees", "Attendee_ID", "dbo.Attendees");
            DropForeignKey("dbo.EventAttendees", "Event_ID", "dbo.Events");
            DropIndex("dbo.EventAttendees", new[] { "Attendee_ID" });
            DropIndex("dbo.EventAttendees", new[] { "Event_ID" });
            DropIndex("dbo.Events", new[] { "CityID" });
            DropColumn("dbo.Events", "CityID");
            DropTable("dbo.EventAttendees");
        }
    }
}
