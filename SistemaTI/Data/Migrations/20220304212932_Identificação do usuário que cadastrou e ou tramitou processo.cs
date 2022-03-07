using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Identificaçãodousuárioquecadastroueoutramitouprocesso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioTramitacao",
                table: "Tramitacao",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UsuarioCadastro",
                table: "Protocolo",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UsuarioTramitacao",
                table: "Tramitacao");

            migrationBuilder.DropColumn(
                name: "UsuarioCadastro",
                table: "Protocolo");
        }
    }
}
