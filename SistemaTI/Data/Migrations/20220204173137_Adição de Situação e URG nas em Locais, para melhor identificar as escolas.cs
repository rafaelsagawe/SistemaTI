using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class AdiçãodeSituaçãoeURGnasemLocaisparamelhoridentificarasescolas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Situacao",
                table: "Local",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "URG",
                table: "Local",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Situacao",
                table: "Local");

            migrationBuilder.DropColumn(
                name: "URG",
                table: "Local");
        }
    }
}
