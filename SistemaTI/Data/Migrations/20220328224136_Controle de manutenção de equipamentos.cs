using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Controledemanutençãodeequipamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Equipamento_EquipamentoManutencaoIdEquipamento",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_EquipamentoManutencaoIdEquipamento",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "EquipamentoManutencaoIdEquipamento",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "IdEquipamentoManutecao",
                table: "Manutencao");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoId",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalId",
                table: "Manutencao",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_EquipamentoId",
                table: "Manutencao",
                column: "EquipamentoId");

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_LocalId",
                table: "Manutencao",
                column: "LocalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Equipamento_EquipamentoId",
                table: "Manutencao",
                column: "EquipamentoId",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Local_LocalId",
                table: "Manutencao",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Equipamento_EquipamentoId",
                table: "Manutencao");

            migrationBuilder.DropForeignKey(
                name: "FK_Manutencao_Local_LocalId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_EquipamentoId",
                table: "Manutencao");

            migrationBuilder.DropIndex(
                name: "IX_Manutencao_LocalId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "EquipamentoId",
                table: "Manutencao");

            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "Manutencao");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoManutencaoIdEquipamento",
                table: "Manutencao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipamentoManutecao",
                table: "Manutencao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Manutencao_EquipamentoManutencaoIdEquipamento",
                table: "Manutencao",
                column: "EquipamentoManutencaoIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Manutencao_Equipamento_EquipamentoManutencaoIdEquipamento",
                table: "Manutencao",
                column: "EquipamentoManutencaoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
