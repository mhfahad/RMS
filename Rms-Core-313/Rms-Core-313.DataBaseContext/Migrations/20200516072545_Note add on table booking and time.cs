using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class Noteaddontablebookingandtime : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Time",
                table: "tableBookingCreates");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "tableBookingCreates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Note",
                table: "tableBookingCreates");

            migrationBuilder.AddColumn<DateTime>(
                name: "Time",
                table: "tableBookingCreates",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
