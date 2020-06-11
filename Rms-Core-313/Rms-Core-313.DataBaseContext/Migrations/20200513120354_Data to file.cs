using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Rms_Core_313.DataBaseContext.Migrations
{
    public partial class Datatofile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "files",
                table: "menusCreates");

            migrationBuilder.AddColumn<byte[]>(
                name: "Data",
                table: "menusCreates",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "menusCreates");

            migrationBuilder.AddColumn<byte[]>(
                name: "files",
                table: "menusCreates",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
