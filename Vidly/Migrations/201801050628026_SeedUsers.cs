namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'8d10cc1a-77e2-43a0-b416-fcb1e6689696', N'themba@meh.co.za', 0, N'AH1gIXcD524dDycdraY04Bz3EsDwzBUbawrVb6BSUeZyYfx1lUs5R4B+SSghGsPtKQ==', N'ead60b6a-0abc-4f60-b8dd-9b4c878728f3', NULL, 0, 0, NULL, 1, 0, N'themba@meh.co.za')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'ed4d3f87-336a-4965-a7a5-e30e9b99b4bd', N'admin@meh.co.za', 0, N'AMknkqrdLefDFpDThv6Q+Yb9wF27wb7rFVI76V/J03OG8tbwTFtahGTXRw5VdgodZQ==', N'de3e92c4-a8eb-4490-b6f9-c1ac80724a61', NULL, 0, 0, NULL, 1, 0, N'admin@meh.co.za')
                    INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'fca7c2ac-55ad-451b-af7b-94b0e0a30c5f', N'manager@meh.co.za', 0, N'AFlGrf6ty+UY70hYBnPpO9/iap8V2NC9+TbWVjNuNj6x5hfYD0XW56RzNi6xoGZcPA==', N'1f1606aa-3d21-455d-9a1c-fdf19483016e', NULL, 0, 0, NULL, 1, 0, N'manager@meh.co.za')
                    INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2609f4b5-3a8e-4e39-8a5c-38ed147962fa', N'CanManageMovies')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'fca7c2ac-55ad-451b-af7b-94b0e0a30c5f', N'2609f4b5-3a8e-4e39-8a5c-38ed147962fa')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
