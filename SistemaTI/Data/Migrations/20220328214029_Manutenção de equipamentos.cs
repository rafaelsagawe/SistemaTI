using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Manutençãodeequipamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "Manutencao",
                columns: table => new
                {
                    ManutencaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Motivo = table.Column<string>(nullable: true),
                    DataSolicitacao = table.Column<DateTime>(nullable: true),
                    EquipamentoManutencaoIdEquipamento = table.Column<int>(nullable: true),
                    IdEquipamentoManutecao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manutencao", x => x.ManutencaoID);
                    table.ForeignKey(
                        name: "FK_Manutencao_Equipamento_EquipamentoManutencaoIdEquipamento",
                        column: x => x.EquipamentoManutencaoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_EquipamentoManutencaoIdEquipamento",
                table: "Manutencao",
                column: "EquipamentoManutencaoIdEquipamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manutencao");

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    SolicitacaoId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdEquipamento = table.Column<int>(type: "int", nullable: false),
                    OrdemServico = table.Column<int>(type: "int", nullable: false),
                    ProblemaReportado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SolicitacaoEquipamentoIdEquipamento = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.SolicitacaoId);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Equipamento_SolicitacaoEquipamentoIdEquipamento",
                        column: x => x.SolicitacaoEquipamentoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "SolicitacaoEquipamentoIdEquipamento");
        }
    }
}
