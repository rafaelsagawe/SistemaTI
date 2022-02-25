using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class ProcessositensV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ItemProcesso",
                columns: table => new
                {
                    IdItemProcesso = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProcesso = table.Column<int>(nullable: false),
                    Item = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    Quantidade = table.Column<int>(nullable: false),
                    ProcessoIdProcesso = table.Column<int>(nullable: true)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ItemProcesso");
        }
    }
}
