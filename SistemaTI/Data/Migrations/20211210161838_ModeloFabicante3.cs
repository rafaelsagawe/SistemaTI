using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class ModeloFabicante3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "ModeloFabicante",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ModeloFabicante_EquipamentoIdEquipamento",
                table: "ModeloFabicante",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_ModeloFabicante_Equipamento_EquipamentoIdEquipamento",
                table: "ModeloFabicante",
                column: "EquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ModeloFabicante_Equipamento_EquipamentoIdEquipamento",
                table: "ModeloFabicante");

            migrationBuilder.DropIndex(
                name: "IX_ModeloFabicante_EquipamentoIdEquipamento",
                table: "ModeloFabicante");

            migrationBuilder.DropColumn(
                name: "EquipamentoIdEquipamento",
                table: "ModeloFabicante");
        }
    }
}
