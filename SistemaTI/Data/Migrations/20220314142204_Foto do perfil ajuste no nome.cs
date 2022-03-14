using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Fotodoperfilajustenonome : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPerfil",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "PerfilFoto",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PerfilFoto",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPerfil",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }
    }
}
