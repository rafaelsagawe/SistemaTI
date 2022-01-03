using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Sistema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Sistema",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SistemaOperacinal",
                table: "Sistema",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Usuario",
                table: "Sistema",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Sistema");

            migrationBuilder.DropColumn(
                name: "SistemaOperacinal",
                table: "Sistema");

            migrationBuilder.DropColumn(
                name: "Usuario",
                table: "Sistema");
        }
    }
}
