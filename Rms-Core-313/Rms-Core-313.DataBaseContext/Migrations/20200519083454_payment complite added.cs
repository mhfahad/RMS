using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class paymentcompliteadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsComplitePayment",
                table: "OrderPlaces",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsComplitePayment",
                table: "OrderPlaces");
        }
    }
}
