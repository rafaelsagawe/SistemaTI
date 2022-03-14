using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class CriaçãodoControllereViewdoWiFi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WiFi",
                columns: table => new
                {
                    IdWifi = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnderecoIP = table.Column<string>(nullable: true),
                    UsuarioADM = table.Column<string>(nullable: true),
                    SenhaADM = table.Column<string>(nullable: true),
                    SSID = table.Column<string>(nullable: true),
                    SenhaSSID = table.Column<string>(nullable: true),
                    DataAlteracao = table.Column<DateTime>(nullable: false),
                    status = table.Column<bool>(nullable: false),
                    LocalId = table.Column<int>(nullable: false),
                    EspecificacaoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WiFi", x => x.IdWifi);
                    table.ForeignKey(
                        name: "FK_WiFi_Especificacao_EspecificacaoId",
                        column: x => x.EspecificacaoId,
                        principalTable: "Especificacao",
                        principalColumn: "EspecificacaoId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_WiFi_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_EspecificacaoId",
                table: "WiFi",
                column: "EspecificacaoId");

            migrationBuilder.CreateIndex(
                name: "IX_WiFi_LocalId",
                table: "WiFi",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WiFi");
        }
    }
}
