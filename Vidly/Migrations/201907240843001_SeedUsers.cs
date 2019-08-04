namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'3bb5b86f-58ee-4910-b532-e6347fdb5a66', N'guest@hemant.com', 0, N'AClMjYRKjxHuYKmq7lw/UvFPWFjT4I8BJG4/mIdaWbcRvRlWTCqYR/mB9Q+/7+2t4w==', N'e68d2fdd-d0bf-4c03-a615-cc3cd84b9a1c', NULL, 0, 0, NULL, 1, 0, N'guest@hemant.com', N'123456', N'9876543121')
                  INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'9665cd6b-5f38-4c0c-9cd8-1c7424314a9e', N'admin@hemant.com', 0, N'AOyIcNW1EBuh59TQXIK2XV5ezJdUBm0ZX20YCvC0bTM5l3bhKcrN271qOBVA+5EqgA==', N'dfa6dcbc-10c7-4d91-816e-70ab3039027a', NULL, 0, 0, NULL, 1, 0, N'admin@hemant.com', N'54321', N'9849494847')
                  INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'0285fb63-ace6-4d5b-a1f8-0a1bcdb8ec01', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9665cd6b-5f38-4c0c-9cd8-1c7424314a9e', N'0285fb63-ace6-4d5b-a1f8-0a1bcdb8ec01')
");

        }
        
        public override void Down()
        {
        }
    }
}
