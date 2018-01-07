namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateMembershipType : DbMigration
    {
        public override void Up()
        {
            Sql("DELETE FROM MembershipTypes");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, MembershipName) VALUES (1, 0, 0, 0, 'Pay as you go')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, MembershipName) VALUES (2, 30, 1, 10, 'Monthly')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, MembershipName) VALUES (3, 90, 3, 15, 'Quaterly')");
            Sql("INSERT INTO MembershipTypes (Id, SignupFee, DurationInMonths, DiscountRate, MembershipName) VALUES (4, 300, 12, 20, 'Annually')");
        }
        
        public override void Down()
        {
        }
    }
}
