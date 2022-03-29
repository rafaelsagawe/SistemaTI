using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Acompanhamentodesolicitaçõesv2Adiçãodeequipamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "Solicitacao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipamento",
                table: "Solicitacao",
                nullable: false,
                defaultValue: 0);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "IdEquipamento",
                table: "Solicitacao");
        }
    }
}
