using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class DocumentosEnviados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Enviado",
                columns: table => new
                {
                    IdEnviado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroDocumento = table.Column<string>(nullable: true),
                    TipoDocumento = table.Column<string>(nullable: true),
                    Destino = table.Column<string>(nullable: true),
                    Assunto = table.Column<string>(nullable: true),
                    ResumoTexto = table.Column<string>(nullable: true),
                    DataEnvio = table.Column<DateTime>(nullable: false),
                    SolitacaoStatus = table.Column<string>(nullable: true),
                    DataAlteração = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enviado", x => x.IdEnviado);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enviado");
        }
    }
}
