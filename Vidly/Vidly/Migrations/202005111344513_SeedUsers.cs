namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'19110578-ba0d-4599-ab6b-015ec073aa0c', N'guest@vidly.com', 0, N'AM4dXHZB/aD+xRPlYKA7T5P6EE0uN9gQ9g10EGjRAa6cZuqGdxVqc47TtNUDgab/xA==', N'3cdb16ca-6edb-4535-9b0e-5748e1c562f1', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
                  INSERT INTO [dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'4d4a3bc3-b33c-4567-9c4f-bd6b7b1018de', N'admin@vidly.com', 0, N'ADzzj0k8hRR71rZsFfub/ejE76w4Km+QOTepOfdt3w/k98m20TUWscSv2hn+ySffWw==', N'6323eedd-7dc0-4e76-8851-23ab23353aa9', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                  INSERT INTO[dbo].[AspNetRoles]([Id], [Name]) VALUES(N'14a3b567-7076-4014-8bdd-691eef2dcc05', N'CanManageMovies')
                  INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4d4a3bc3-b33c-4567-9c4f-bd6b7b1018de', N'14a3b567-7076-4014-8bdd-691eef2dcc05')");

        }
        
        public override void Down()
        {
        }
    }
}
