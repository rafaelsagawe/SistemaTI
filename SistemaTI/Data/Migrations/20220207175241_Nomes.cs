using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Nomes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPefil",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LimiteTrocaNome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimeiroNome",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SobreNome",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPefi",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LimiteTrocaNom",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimeiroNom",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SobreNom",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FotoPefi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LimiteTrocaNom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PrimeiroNom",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SobreNom",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "FotoPefil",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LimiteTrocaNome",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PrimeiroNome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SobreNome",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
