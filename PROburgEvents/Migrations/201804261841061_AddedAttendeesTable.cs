namespace PROburgEvents.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAttendeesTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Attendees");
        }
    }
}
