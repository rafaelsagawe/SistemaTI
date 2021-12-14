using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Documentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Documentos",
                columns: table => new
                {
                    IdDocumento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoDocumento = table.Column<string>(nullable: true),
                    NumeroDocumento = table.Column<int>(nullable: false),
                    Destinatario = table.Column<string>(nullable: true),
                    Assunto = table.Column<string>(nullable: true),
                    Conteudo = table.Column<string>(nullable: true),
                    DataDocumento = table.Column<DateTime>(nullable: false),
                    Status = table.Column<string>(nullable: true),
                    grauImportancia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documentos", x => x.IdDocumento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Documentos");
        }
    }
}
