namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMoviesTableAvailableColumnValuesAgain : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Movies SET NumberInStock = NumberAvailable");
        }
        
        public override void Down()
        {
        }
    }
}
