using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Documentosrecebidosadiçãodecampos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Texto",
                table: "Recebido",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaMovimentacao",
                table: "Recebido",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Texto",
                table: "Recebido");

            migrationBuilder.DropColumn(
                name: "UltimaMovimentacao",
                table: "Recebido");
        }
    }
}
