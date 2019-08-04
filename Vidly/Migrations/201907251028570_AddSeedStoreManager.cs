namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSeedStoreManager : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO[dbo].[AspNetRoles]
               ([Id], [Name]) VALUES(N'1cafbfc9-28a6-4dbd-8cdf-84f5a2f6f670', N'StoreManager')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'71491668-6345-425e-9fa8-649dbfa4f6f9', N'storemgr@hemant.com', 0, N'APDFjAxhQR14Ett0HR2MJG4BNvoggf5Njjzw++D2/WtOk5zxtgCf/leGH/2o7xrMdg==', N'fd69fe15-cdb0-486d-b092-30b28a9df47c', NULL, 0, 0, NULL, 1, 0, N'storemgr@hemant.com', N'287983789', N'9893833871')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'71491668-6345-425e-9fa8-649dbfa4f6f9', N'1cafbfc9-28a6-4dbd-8cdf-84f5a2f6f670')");


        }
        
        public override void Down()
        {
        }
    }
}
