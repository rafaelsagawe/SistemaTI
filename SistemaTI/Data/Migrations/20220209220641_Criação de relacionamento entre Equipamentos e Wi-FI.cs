using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class CriaçãoderelacionamentoentreEquipamentoseWiFI : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Equipamento",
                table: "WiFi");

            migrationBuilder.AddColumn<int>(
                name: "WiFiIdWifi",
                table: "Equipamento",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_WiFiIdWifi",
                table: "Equipamento",
                column: "WiFiIdWifi");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_WiFi_WiFiIdWifi",
                table: "Equipamento",
                column: "WiFiIdWifi",
                principalTable: "WiFi",
                principalColumn: "IdWifi",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_WiFi_WiFiIdWifi",
                table: "Equipamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_WiFiIdWifi",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "WiFiIdWifi",
                table: "Equipamento");

            migrationBuilder.AddColumn<string>(
                name: "Equipamento",
                table: "WiFi",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
