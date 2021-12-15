using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class WiFi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WiFi",
                columns: table => new
                {
                    IdWifi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    equipamentoIDIdEquipamento = table.Column<int>(nullable: true),
                    UsuarioADM = table.Column<string>(nullable: true),
                    SenhaADM = table.Column<string>(nullable: true),
                    SSID = table.Column<string>(nullable: true),
                    SenhaSSID = table.Column<string>(nullable: true),
                    LocalididLocal = table.Column<int>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WiFi", x => x.IdWifi);
                    table.ForeignKey(
                        name: "FK_WiFi_Local_LocalididLocal",
                        column: x => x.LocalididLocal,
                        principalTable: "Local",
                        principalColumn: "idLocal",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_WiFi_Equipamento_equipamentoIDIdEquipamento",
                        column: x => x.equipamentoIDIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_LocalididLocal",
                table: "WiFi",
                column: "LocalididLocal");

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_equipamentoIDIdEquipamento",
                table: "WiFi",
                column: "equipamentoIDIdEquipamento");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WiFi");
        }
    }
}
