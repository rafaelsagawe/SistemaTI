using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Equipamento3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Equipamento",
                columns: table => new
                {
                    IdEquipamento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NuSerie = table.Column<string>(nullable: true),
                    NuPatrimonio = table.Column<string>(nullable: true),
                    EquipTipo = table.Column<string>(nullable: true),
                    Modelo = table.Column<string>(nullable: true),
                    EquipOrigem = table.Column<string>(nullable: true),
                    EquipValor = table.Column<int>(nullable: false),
                    Local = table.Column<string>(nullable: true),
                    IP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipamento", x => x.IdEquipamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Equipamento");
        }
    }
}
