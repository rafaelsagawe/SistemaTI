using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Criaçãodocadastrodesuprimentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suprimento",
                columns: table => new
                {
                    idSuprimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EspecificacaoId = table.Column<int>(nullable: false),
                    TipoSuprimento = table.Column<string>(nullable: true),
                    QtdSuprimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimento", x => x.idSuprimento);
                    table.ForeignKey(
                        name: "FK_Suprimento_Especificacao_EspecificacaoId",
                        column: x => x.EspecificacaoId,
                        principalTable: "Especificacao",
                        principalColumn: "EspecificacaoId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suprimento_EspecificacaoId",
                table: "Suprimento",
                column: "EspecificacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suprimento");
        }
    }
}
