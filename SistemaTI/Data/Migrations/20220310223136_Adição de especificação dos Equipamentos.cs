using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class AdiçãodeespecificaçãodosEquipamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Especificacao_Equipamento_EquipamentoIdEquipamento",
                table: "Especificacao");

            migrationBuilder.DropForeignKey(
                name: "FK_Especificacao_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao");

            migrationBuilder.DropIndex(
                name: "IX_Especificacao_EquipamentoIdEquipamento",
                table: "Especificacao");

            migrationBuilder.DropIndex(
                name: "IX_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao");

            migrationBuilder.DropColumn(
                name: "EquipamentoIdEquipamento",
                table: "Especificacao");

            migrationBuilder.DropColumn(
                name: "EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao");

            migrationBuilder.DropColumn(
                name: "IdEquipamento",
                table: "Especificacao");

            migrationBuilder.AddColumn<int>(
                name: "EspecificacaoId",
                table: "Equipamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Equipamento_EspecificacaoId",
                table: "Equipamento",
                column: "EspecificacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento",
                column: "EspecificacaoId",
                principalTable: "Especificacao",
                principalColumn: "EspecificacaoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Especificacao_EspecificacaoId",
                table: "Equipamento");

            migrationBuilder.DropIndex(
                name: "IX_Equipamento_EspecificacaoId",
                table: "Equipamento");

            migrationBuilder.DropColumn(
                name: "EspecificacaoId",
                table: "Equipamento");

            migrationBuilder.AddColumn<int>(
                name: "EquipamentoIdEquipamento",
                table: "Especificacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "IdEquipamento",
                table: "Especificacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Especificacao_EquipamentoIdEquipamento",
                table: "Especificacao",
                column: "EquipamentoIdEquipamento");

            migrationBuilder.CreateIndex(
                name: "IX_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao",
                column: "EspecificacaoEquipamentoEspecificacaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Especificacao_Equipamento_EquipamentoIdEquipamento",
                table: "Especificacao",
                column: "EquipamentoIdEquipamento",
                principalTable: "Equipamento",
                principalColumn: "IdEquipamento",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Especificacao_Especificacao_EspecificacaoEquipamentoEspecificacaoId",
                table: "Especificacao",
                column: "EspecificacaoEquipamentoEspecificacaoId",
                principalTable: "Especificacao",
                principalColumn: "EspecificacaoId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
