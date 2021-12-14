using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Solicitacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "grauImportancia",
                table: "Documentos");

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    IdSolicitacao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataRecebimento = table.Column<DateTime>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    TextoSolicitacao = table.Column<string>(nullable: true),
                    Equipamento = table.Column<string>(nullable: true),
                    SolitacaoStatus = table.Column<string>(nullable: true),
                    OrdemServico = table.Column<string>(nullable: true),
                    DataAtendimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.IdSolicitacao);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.AddColumn<int>(
                name: "grauImportancia",
                table: "Documentos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
