using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Protocolo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Protocolo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Processo = table.Column<string>(nullable: true),
                    Assunto = table.Column<string>(nullable: true),
                    Prazo = table.Column<int>(nullable: false),
                    DataEntrada = table.Column<DateTime>(nullable: false),
                    DataRegistro = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Protocolo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tramitacao",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dateTime = table.Column<DateTime>(nullable: false),
                    Localizacao = table.Column<string>(nullable: true),
                    ProtocoloId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tramitacao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tramitacao_Protocolo_ProtocoloId",
                        column: x => x.ProtocoloId,
                        principalTable: "Protocolo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacao_ProtocoloId",
                table: "Tramitacao",
                column: "ProtocoloId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tramitacao");

            migrationBuilder.DropTable(
                name: "Protocolo");
        }
    }
}
