using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class AcompanhamentodesolicitaçõesAdiçãodeequipamentosv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Equipamento_EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.AddColumn<int>(
                name: "SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "SolicitacaoEquipamentoIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Equipamento_SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "SolicitacaoEquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Equipamento_SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "SolicitacaoEquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "Solicitacao",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_EquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Equipamento_EquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "EquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
