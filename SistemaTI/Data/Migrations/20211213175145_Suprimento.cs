using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Suprimento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suprimento",
                columns: table => new
                {
                    idSuprimento = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModeloEquipamento = table.Column<string>(nullable: true),
                    TipoSuprimento = table.Column<string>(nullable: true),
                    QtdSuprimento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suprimento", x => x.idSuprimento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suprimento");
        }
    }
}
