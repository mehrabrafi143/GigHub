namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNotificationAndUserNotificationModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateTime = c.DateTime(nullable: false),
                        NotificationType = c.Byte(nullable: false),
                        OriginalDateTime = c.DateTime(),
                        OriginalVeneu = c.String(),
                        GigId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gigs", t => t.GigId, cascadeDelete: true)
                .Index(t => t.GigId);
            
            CreateTable(
                "dbo.UserNotifications",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        NotificationId = c.Int(nullable: false),
                        IsRead = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.NotificationId })
                .ForeignKey("dbo.Notifications", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserNotifications", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UserNotifications", "NotificationId", "dbo.Notifications");
            DropForeignKey("dbo.Notifications", "GigId", "dbo.Gigs");
            DropIndex("dbo.UserNotifications", new[] { "NotificationId" });
            DropIndex("dbo.UserNotifications", new[] { "UserId" });
            DropIndex("dbo.Notifications", new[] { "GigId" });
            DropTable("dbo.UserNotifications");
            DropTable("dbo.Notifications");
        }
    }
}
