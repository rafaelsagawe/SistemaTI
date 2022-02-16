using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class WiFiCriaçãodacoleçãolocais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localid",
                table: "WiFi");

            migrationBuilder.AddColumn<int>(
                name: "WiFiIdWifi",
                table: "Local",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Local_WiFiIdWifi",
                table: "Local",
                column: "WiFiIdWifi");

            migrationBuilder.AddForeignKey(
                name: "FK_Local_WiFi_WiFiIdWifi",
                table: "Local",
                column: "WiFiIdWifi",
                principalTable: "WiFi",
                principalColumn: "IdWifi",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Local_WiFi_WiFiIdWifi",
                table: "Local");

            migrationBuilder.DropIndex(
                name: "IX_Local_WiFiIdWifi",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "WiFiIdWifi",
                table: "Local");

            migrationBuilder.AddColumn<int>(
                name: "Localid",
                table: "WiFi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
