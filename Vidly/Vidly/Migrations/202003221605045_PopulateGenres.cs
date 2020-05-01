namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Web.Mvc.Ajax;

    public partial class PopulateGenres : DbMigration
    {
        public override void Up() { 
            Sql("INSERT INTO Genres (Id, Name) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (2, 'Romance')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (3, 'Thriller')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (4, 'Horror')");
            Sql("INSERT INTO Genres (Id, Name) VALUES (5, 'Comedy')");
        }
        
        public override void Down()
        {

        }
    }
}
