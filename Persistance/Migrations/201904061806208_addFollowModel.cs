namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addFollowModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Follows",
                c => new
                    {
                        ArtistId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.ArtistId, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.ArtistId)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.ArtistId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Follows", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Follows", new[] { "UserId" });
            DropIndex("dbo.Follows", new[] { "ArtistId" });
            DropTable("dbo.Follows");
        }
    }
}
