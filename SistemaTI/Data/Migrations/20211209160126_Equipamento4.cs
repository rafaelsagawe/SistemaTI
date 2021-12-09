using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Equipamento4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataMovimantacao",
                table: "Equipamento",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Equipamento",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataMovimantacao",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Equipamento");
        }
    }
}
