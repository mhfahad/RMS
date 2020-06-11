using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class Phonenofieldaddedorderplace : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReciverPhone",
                table: "OrderPlaces",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReciverPhone",
                table: "OrderPlaces");
        }
    }
}
