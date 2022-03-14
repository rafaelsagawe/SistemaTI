using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Ajustesnobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimiteTrocaNome",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LimiteTroca",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LimiteTroca",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "LimiteTrocaNome",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
