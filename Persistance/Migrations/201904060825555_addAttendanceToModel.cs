namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addAttendanceToModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Attendances",
                c => new
                    {
                        GigId = c.Int(nullable: false),
                        AttendeeId = c.String(nullable: false, maxLength: 128),
                        Attendee_RequireUniqueEmail = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.GigId, t.AttendeeId })
                .ForeignKey("dbo.Gigs", t => t.GigId, cascadeDelete: true)
                .Index(t => t.GigId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            DropIndex("dbo.Attendances", new[] { "GigId" });
            DropTable("dbo.Attendances");
        }
    }
}
