namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctTheAttendanceModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            CreateIndex("dbo.Attendances", "AttendeeId");
            AddForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Attendances", "GigId", "dbo.Gigs", "Id");
            DropColumn("dbo.Attendances", "Attendee_RequireUniqueEmail");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Attendances", "Attendee_RequireUniqueEmail", c => c.Boolean(nullable: false));
            DropForeignKey("dbo.Attendances", "GigId", "dbo.Gigs");
            DropForeignKey("dbo.Attendances", "AttendeeId", "dbo.AspNetUsers");
            DropIndex("dbo.Attendances", new[] { "AttendeeId" });
            AddForeignKey("dbo.Attendances", "GigId", "dbo.Gigs", "Id", cascadeDelete: true);
        }
    }
}
