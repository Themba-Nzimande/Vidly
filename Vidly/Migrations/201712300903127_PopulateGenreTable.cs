namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateGenreTable : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (1, 'Action')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (2, 'Comedy')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (3, 'Horror')");
            Sql("INSERT INTO Genres (Id, GenreName) VALUES (4, 'Romantic')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
