using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class DivisãodocampoEndereço : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Local");

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Local",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Logradouro",
                table: "Local",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Numero",
                table: "Local",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "Logradouro",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Local");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Local",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
