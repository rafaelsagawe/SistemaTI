using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class WiFiEquipamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WiFi_Equipamento_equipamentoIDIdEquipamento",
                table: "WiFi");

            migrationBuilder.DropIndex(
                name: "IX_WiFi_equipamentoIDIdEquipamento",
                table: "WiFi");

            migrationBuilder.DropColumn(
                name: "equipamentoIDIdEquipamento",
                table: "WiFi");

            migrationBuilder.AddColumn<string>(
                name: "Equipamento",
                table: "WiFi",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipamento",
                table: "WiFi");

            migrationBuilder.AddColumn<int>(
                name: "equipamentoIDIdEquipamento",
                table: "WiFi",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_equipamentoIDIdEquipamento",
                table: "WiFi",
                column: "equipamentoIDIdEquipamento");

            migrationBuilder.AddForeignKey(
                name: "FK_WiFi_Equipamento_equipamentoIDIdEquipamento",
                table: "WiFi",
                column: "equipamentoIDIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
