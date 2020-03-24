using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ.Data.Migrations
{
    public partial class AddDateTimeFieldForCook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "WhenFinishes",
                table: "Cooks",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WhenFinishes",
                table: "Cooks");
        }
    }
}
