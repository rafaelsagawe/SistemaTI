using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class MelhoriasnoSistemas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desenvolvedor",
                table: "Sistema",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Licenca",
                table: "Sistema",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desenvolvedor",
                table: "Sistema");

            migrationBuilder.DropColumn(
                name: "Licenca",
                table: "Sistema");
        }
    }
}
