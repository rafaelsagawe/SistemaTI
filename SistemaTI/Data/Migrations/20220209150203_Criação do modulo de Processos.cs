using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class CriaçãodomodulodeProcessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Processo",
                columns: table => new
                {
                    IdProcesso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Objeto = table.Column<string>(nullable: true),
                    NumeroProcesso = table.Column<string>(nullable: true),
                    Tipo = table.Column<string>(nullable: true),
                    Inicio = table.Column<DateTime>(nullable: false),
                    Vigencia = table.Column<int>(nullable: false),
                    Finalizacao = table.Column<DateTime>(nullable: false),
                    Renovacao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Processo", x => x.IdProcesso);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Processo");
        }
    }
}
