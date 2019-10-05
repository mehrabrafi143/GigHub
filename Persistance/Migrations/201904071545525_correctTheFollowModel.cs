namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correctTheFollowModel : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Follows", "UserId", "dbo.AspNetUsers");
            RenameColumn(table: "dbo.Follows", name: "ArtistId", newName: "FollowerId");
            RenameColumn(table: "dbo.Follows", name: "UserId", newName: "FolloweeId");
            RenameIndex(table: "dbo.Follows", name: "IX_UserId", newName: "IX_FolloweeId");
            RenameIndex(table: "dbo.Follows", name: "IX_ArtistId", newName: "IX_FollowerId");
            DropPrimaryKey("dbo.Follows");
            AddPrimaryKey("dbo.Follows", new[] { "FolloweeId", "FollowerId" });
            AddForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Follows", "FolloweeId", "dbo.AspNetUsers");
            DropPrimaryKey("dbo.Follows");
            AddPrimaryKey("dbo.Follows", new[] { "ArtistId", "UserId" });
            RenameIndex(table: "dbo.Follows", name: "IX_FollowerId", newName: "IX_ArtistId");
            RenameIndex(table: "dbo.Follows", name: "IX_FolloweeId", newName: "IX_UserId");
            RenameColumn(table: "dbo.Follows", name: "FolloweeId", newName: "UserId");
            RenameColumn(table: "dbo.Follows", name: "FollowerId", newName: "ArtistId");
            AddForeignKey("dbo.Follows", "UserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
