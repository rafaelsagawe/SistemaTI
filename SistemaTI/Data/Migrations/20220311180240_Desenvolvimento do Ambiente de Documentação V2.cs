using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class DesenvolvimentodoAmbientedeDocumentaçãoV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroProcesso = table.Column<string>(nullable: true),
                    Assunto = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Prazo = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false),
                    Renovacao = table.Column<int>(nullable: false),
                    UsuarioCadastro = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ItensProcesso",
                columns: table => new
                {
                    ItensProcessoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Item = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    QTD = table.Column<int>(nullable: false),
                    Medida = table.Column<string>(nullable: true),
                    ProtocoloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItensProcesso", x => x.ItensProcessoId);
                    table.ForeignKey(
                        name: "FK_ItensProcesso_Processo_ProtocoloId",
                        column: x => x.ProtocoloId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tramitacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Movimentacao = table.Column<DateTime>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true),
                    UsuarioTramitacao = table.Column<string>(nullable: true),
                    ProtocoloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramitacao_Processo_ProtocoloId",
                        column: x => x.ProtocoloId,
                        principalTable: "Processo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItensProcesso_ProtocoloId",
                table: "ItensProcesso",
                column: "ProtocoloId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacao_ProtocoloId",
                table: "Tramitacao",
                column: "ProtocoloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItensProcesso");

            migrationBuilder.DropTable(
                name: "Tramitacao");

            migrationBuilder.DropTable(
                name: "Processo");
        }
    }
}
