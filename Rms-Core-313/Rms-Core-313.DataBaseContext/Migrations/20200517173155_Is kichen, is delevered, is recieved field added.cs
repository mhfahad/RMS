using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class Iskichenisdeleveredisrecievedfieldadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelivering",
                table: "OrderPlaces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInKichen",
                table: "OrderPlaces",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRecived",
                table: "OrderPlaces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelivering",
                table: "OrderPlaces");

            migrationBuilder.DropColumn(
                name: "IsInKichen",
                table: "OrderPlaces");

            migrationBuilder.DropColumn(
                name: "IsRecived",
                table: "OrderPlaces");
        }
    }
}
