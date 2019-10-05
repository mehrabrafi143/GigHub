namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addArtistIdToGigTableCorrection : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            DropColumn("dbo.Gigs", "ArtistId");
            RenameColumn(table: "dbo.Gigs", name: "Artist_Id", newName: "ArtistId");
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Gigs", "ArtistId");
            AddForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "ArtistId", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "ArtistId" });
            AlterColumn("dbo.Gigs", "ArtistId", c => c.String(maxLength: 128));
            AlterColumn("dbo.Gigs", "ArtistId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Gigs", name: "ArtistId", newName: "Artist_Id");
            AddColumn("dbo.Gigs", "ArtistId", c => c.Int(nullable: false));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
