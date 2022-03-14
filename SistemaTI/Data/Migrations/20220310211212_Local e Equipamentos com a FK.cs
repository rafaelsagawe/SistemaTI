using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class LocaleEquipamentoscomaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Local",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    localTipo = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    NunProtocolo = table.Column<int>(nullable: false),
                    INEP = table.Column<int>(nullable: false),
                    URG = table.Column<string>(nullable: true),
                    Logradouro = table.Column<string>(nullable: true),
                    Numero = table.Column<string>(nullable: true),
                    Bairro = table.Column<string>(nullable: true),
                    CEP = table.Column<int>(nullable: false),
                    Zona = table.Column<string>(nullable: true),
                    Telefone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true),
                    Laboratorio = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Local", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuSerie = table.Column<string>(nullable: true),
                    NuPatrimonio = table.Column<string>(nullable: true),
                    EquipTipo = table.Column<string>(nullable: true),
                    EquipOrigem = table.Column<string>(nullable: true),
                    EquipValor = table.Column<float>(nullable: true),
                    IP = table.Column<string>(nullable: true),
                    Situacao = table.Column<string>(nullable: true),
                    DataMovimantacao = table.Column<DateTime>(nullable: false),
                    LocalId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                    table.ForeignKey(
                        name: "FK_Equipamento_Local_LocalId",
                        column: x => x.LocalId,
                        principalTable: "Local",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_LocalId",
                table: "Equipamento",
                column: "LocalId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");

            migrationBuilder.DropTable(
                name: "Local");
        }
    }
}
