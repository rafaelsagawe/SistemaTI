using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class ProcessositensREMOÇÃO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemProcesso");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemProcesso",
                columns: table => new
                {
                    IdItemProcesso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdProcesso = table.Column<int>(type: "int", nullable: false),
                    Item = table.Column<int>(type: "int", nullable: false),
                    ProcessoIdProcesso = table.Column<int>(type: "int", nullable: true),
                    Quantidade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemProcesso", x => x.IdItemProcesso);
                    table.ForeignKey(
                        name: "FK_ItemProcesso_Processo_ProcessoIdProcesso",
                        column: x => x.ProcessoIdProcesso,
                        principalTable: "Processo",
                        principalColumn: "IdProcesso",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ItemProcesso_ProcessoIdProcesso",
                table: "ItemProcesso",
                column: "ProcessoIdProcesso");
        }
    }
}
