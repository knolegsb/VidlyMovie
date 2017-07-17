namespace VidlyMovie.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0820001b-a2fa-4f04-a61c-46e18d638eb3', N'good@hotmail.com', 0, N'AMWy5dKH6g/dVJLcsLLy7jB7fYs4ZmYUH5ri+G3VDoguiO+wcibL+cD7Qewzn60tjQ==', N'a844d001-4436-4b4e-a056-d2e0ae0fed95', NULL, 0, 0, NULL, 1, 0, N'good@hotmail.com')
              INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'd2b76cfb-4413-4159-9f22-3ddde7033ad2', N'sean@example.com', 0, N'ALlz6O2kswYeSSYRGRLPQzDNyiPfn5BYH5mAuT+YnSrBye/v476OF7bdqfjilvu0pA==', N'395e4932-e170-484b-80f0-275a686df93c', NULL, 0, 0, NULL, 1, 0, N'sean@example.com')
             INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'd8b4491f-cad9-40a9-9d52-365a90395a35', N'CanManageMovies')
             INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0820001b-a2fa-4f04-a61c-46e18d638eb3', N'd8b4491f-cad9-40a9-9d52-365a90395a35')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
