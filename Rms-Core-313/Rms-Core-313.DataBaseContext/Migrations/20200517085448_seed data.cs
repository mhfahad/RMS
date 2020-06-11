using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class seeddata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT[dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) 
                                VALUES(N'3a494f85-a405-4b92-b45e-4e239077ece1', N'SuperAdmin', N'SUPERADMIN', N'mtohasan@gmail.com', N'MTOHASAN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEHn3uDS8TwtpOYEBXIZMYUhyFpg50Gsd4neyjGcRyxqhkSnh0Mxx72Mfc4BJPCXQow==', N'ICHLCWO5ZTXOFX6EOEL2BOIXQJ2ZSHA2', N'16964e28-625f-4fb4-8c1e-aebe36d25055', NULL, 0, 0, NULL, 1, 0)
            ");
            migrationBuilder.Sql(@"INSERT[dbo].[AspNetRoles]([Id], [Name], [NormalizedName], [ConcurrencyStamp]) 
                                VALUES(N'12345', N'SuperAdmin', NULL, NULL)
            ");
            migrationBuilder.Sql(@"INSERT[dbo].[AspNetUserRoles]([UserId], [RoleId]) 
                                VALUES(N'3a494f85-a405-4b92-b45e-4e239077ece1', N'12345')
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
