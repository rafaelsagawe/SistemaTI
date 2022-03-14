using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class EspecificaçõescomaFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Especificacao",
                columns: table => new
                {
                    EspecificacaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo = table.Column<string>(nullable: false),
                    Fabicante = table.Column<string>(nullable: false),
                    Modelo = table.Column<string>(nullable: false),
                    IdEquipamento = table.Column<int>(nullable: false),
                    EspecificacaoEquipamentoEspecificacaoId = table.Column<int>(nullable: true),
                    EquipamentoIdEquipamento = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Especificacao", x => x.EspecificacaoId);
                    table.ForeignKey(
                        name: "FK_Especificacao_Equipamento_EquipamentoIdEquipamento",
                        column: x => x.EquipamentoIdEquipamento,
                        principalTable: "Equipamento",
                        principalColumn: "IdEquipamento",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Especificacao_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                        column: x => x.EspecificacaoEquipamentoEspecificacaoId,
                        principalTable: "Especificacao",
                        principalColumn: "EspecificacaoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Especificacao_EquipamentoIdEquipamento",
                table: "Especificacao",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao",
                column: "EspecificacaoEquipamentoEspecificacaoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Especificacao");
        }
    }
}
