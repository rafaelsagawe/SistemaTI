using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Acompanhamentodesolicitaçõesv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Equipamento_EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Solicitacao_Local_LocalId",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropIndex(
                name: "IX_Solicitacao_LocalId",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "EquipamentoIdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "IdEquipamento",
                table: "Solicitacao");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Solicitacao");

            migrationBuilder.AddColumn<int>(
                name: "OrdemServico",
                table: "Solicitacao",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrdemServico",
                table: "Solicitacao");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "Solicitacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipamento",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Solicitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_EquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Solicitacao_LocalId",
                table: "Solicitacao",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Equipamento_EquipamentoIdEquipamento",
                table: "Solicitacao",
                column: "EquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Solicitacao_Local_LocalId",
                table: "Solicitacao",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
