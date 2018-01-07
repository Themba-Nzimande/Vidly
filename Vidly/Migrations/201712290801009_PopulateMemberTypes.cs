namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateMemberTypes : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (1, 0, 0, 0, 'Pay as you go')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (2, 30, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (3, 90, 3, 15, 'Quaterly')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate) VALUES (4, 300, 12, 20, 'Annually')");
        }
        
        public override void Down()
        {
        }
    }
}
