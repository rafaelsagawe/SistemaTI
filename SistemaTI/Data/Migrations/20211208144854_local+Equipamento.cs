using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class localEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "Local",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Local_EquipamentoIdEquipamento",
                table: "Local",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_Equipamento_EquipamentoIdEquipamento",
                table: "Local",
                column: "EquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_Equipamento_EquipamentoIdEquipamento",
                table: "Local");

            migrationBuilder.DropIndex(
                name: "IX_Local_EquipamentoIdEquipamento",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "EquipamentoIdEquipamento",
                table: "Local");
        }
    }
}
