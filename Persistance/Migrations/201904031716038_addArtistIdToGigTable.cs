namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addArtistIdToGigTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AddColumn("dbo.Gigs", "ArtistId", c => c.Int(nullable: false));
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Gigs", new[] { "Artist_Id" });
            AlterColumn("dbo.Gigs", "Artist_Id", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Gigs", "ArtistId");
            CreateIndex("dbo.Gigs", "Artist_Id");
            AddForeignKey("dbo.Gigs", "Artist_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
