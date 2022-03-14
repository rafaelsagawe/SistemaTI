using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Equipamentostornarpropriedadesdenavegaçãonula : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Local_LocalId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessoId",
                table: "Equipamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Equipamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "EspecificacaoId",
                table: "Equipamento",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento",
                column: "EspecificacaoId",
                principalTable: "Especificacao",
                principalColumn: "EspecificacaoId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Local_LocalId",
                table: "Equipamento",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Local_LocalId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento");

            migrationBuilder.AlterColumn<int>(
                name: "ProcessoId",
                table: "Equipamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "LocalId",
                table: "Equipamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "EspecificacaoId",
                table: "Equipamento",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento",
                column: "EspecificacaoId",
                principalTable: "Especificacao",
                principalColumn: "EspecificacaoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Local_LocalId",
                table: "Equipamento",
                column: "LocalId",
                principalTable: "Local",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
