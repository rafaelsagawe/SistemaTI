using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class WiFiCriaçãodacoleçãolocaisv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Localid",
                table: "WiFi");

            migrationBuilder.AddColumn<int>(
                name: "LocalididLocal",
                table: "WiFi",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_LocalididLocal",
                table: "WiFi",
                column: "LocalididLocal");

            migrationBuilder.AddForeignKey(
                name: "FK_WiFi_Local_LocalididLocal",
                table: "WiFi",
                column: "LocalididLocal",
                principalTable: "Local",
                principalColumn: "idLocal",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WiFi_Local_LocalididLocal",
                table: "WiFi");

            migrationBuilder.DropIndex(
                name: "IX_WiFi_LocalididLocal",
                table: "WiFi");

            migrationBuilder.DropColumn(
                name: "LocalididLocal",
                table: "WiFi");

            migrationBuilder.AddColumn<int>(
                name: "Localid",
                table: "WiFi",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
