using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TRPZ.Data.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cooks",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cooks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CuisineTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CuisineType = table.Column<string>(nullable: true),
                    CookEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CuisineTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CuisineTypes_Cooks_CookEntityId",
                        column: x => x.CookEntityId,
                        principalTable: "Cooks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dishes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    CookingTime = table.Column<TimeSpan>(nullable: false),
                    Weight = table.Column<int>(nullable: false),
                    CuisineTypeId = table.Column<int>(nullable: true),
                    Price = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dishes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dishes_CuisineTypes_CuisineTypeId",
                        column: x => x.CuisineTypeId,
                        principalTable: "CuisineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ingredient = table.Column<string>(nullable: true),
                    DishEntityId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingredients_Dishes_DishEntityId",
                        column: x => x.DishEntityId,
                        principalTable: "Dishes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CuisineTypes_CookEntityId",
                table: "CuisineTypes",
                column: "CookEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Dishes_CuisineTypeId",
                table: "Dishes",
                column: "CuisineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingredients_DishEntityId",
                table: "Ingredients",
                column: "DishEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Dishes");

            migrationBuilder.DropTable(
                name: "CuisineTypes");

            migrationBuilder.DropTable(
                name: "Cooks");
        }
    }
}
