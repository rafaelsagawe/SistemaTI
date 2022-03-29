using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Acompanhamentodesolicitações : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.CreateTable(
                name: "Solicitacao",
                columns: table => new
                {
                    SolicitacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    ProblemaReportado = table.Column<string>(nullable: true),
                    LocalId = table.Column<int>(nullable: false),
                    IdEquipamento = table.Column<int>(nullable: false),
                    EquipamentoIdEquipamento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solicitacao", x => x.SolicitacaoId);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Equipamento_EquipamentoIdEquipamento",
                        column: x => x.EquipamentoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Solicitacao_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_EquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_LocalId",
                table: "Solicitacao",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solicitacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItensProcesso",
                table: "ItensProcesso");

            migrationBuilder.DropColumn(
                name: "ItensProcessoId",
                table: "ItensProcesso");

            migrationBuilder.AddColumn<int>(
                name: "EquiItensProcessoId",
                table: "ItensProcesso",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItensProcesso",
                table: "ItensProcesso",
                column: "EquiItensProcessoId");
        }
    }
}
