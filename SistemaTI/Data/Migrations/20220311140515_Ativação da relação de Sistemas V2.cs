using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class AtivaçãodarelaçãodeSistemasV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sistema",
                columns: table => new
                {
                    IdSistema = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeSistema = table.Column<string>(nullable: true),
                    NomePlataforma = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Acesso = table.Column<string>(nullable: true),
                    SistemaOperacinal = table.Column<string>(nullable: true),
                    Usuario = table.Column<string>(nullable: true),
                    Senha = table.Column<string>(nullable: true),
                    CodigoFonte = table.Column<string>(nullable: true),
                    Linguagem = table.Column<string>(nullable: true),
                    BandoDados = table.Column<string>(nullable: true),
                    Documentacao = table.Column<string>(nullable: true),
                    Desenvolvedor = table.Column<string>(nullable: true),
                    Licenca = table.Column<string>(nullable: true),
                    Hospedagem = table.Column<string>(nullable: true),
                    Clientes = table.Column<string>(nullable: true),
                    EstadoDesenvolvimento = table.Column<string>(nullable: true),
                    Criticidade = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sistema", x => x.IdSistema);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sistema");
        }
    }
}
