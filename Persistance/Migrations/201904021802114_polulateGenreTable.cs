namespace GigHub.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class polulateGenreTable : DbMigration
    {
        public override void Up()
        {
	        Sql("Insert into Genres(Id, Name) Values(1,'Jazz')");
	        Sql("Insert into Genres(Id, Name) Values(2,'Rock')");
	        Sql("Insert into Genres(Id, Name) Values(3,'Pop')");
	        Sql("Insert into Genres(Id, Name) Values(4,'Soft')");
	        Sql("Insert into Genres(Id, Name) Values(5,'Melody')");
	        Sql("Insert into Genres(Id, Name) Values(6,'Country')");
        }
        
        public override void Down()
        {
			Sql("delete from Genres Where Id in (1,2,3,4,5,6)");
        }
    }
}
