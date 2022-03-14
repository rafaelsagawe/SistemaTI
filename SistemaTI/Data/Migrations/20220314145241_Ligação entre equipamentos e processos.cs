using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Ligaçãoentreequipamentoseprocessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipOrigem",
                table: "Equipamento");

            migrationBuilder.AddColumn<int>(
                name: "ProcessoID",
                table: "Equipamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_ProcessoID",
                table: "Equipamento",
                column: "ProcessoID");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Processo_ProcessoID",
                table: "Equipamento",
                column: "ProcessoID",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Processo_ProcessoID",
                table: "Equipamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_ProcessoID",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "ProcessoID",
                table: "Equipamento");

            migrationBuilder.AddColumn<string>(
                name: "EquipOrigem",
                table: "Equipamento",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
