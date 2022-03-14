using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaTI.Data.Migrations
{
    public partial class Ligaçãoentreequipamentoseprocessosajustesemprocessos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Processo_ProcessoID",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensProcesso_Processo_ProtocoloId",
                table: "ItensProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramitacao_Processo_ProtocoloId",
                table: "Tramitacao");

            migrationBuilder.DropIndex(
                name: "IX_Tramitacao_ProtocoloId",
                table: "Tramitacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processo",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_ItensProcesso_ProtocoloId",
                table: "ItensProcesso");

            migrationBuilder.DropColumn(
                name: "ProtocoloId",
                table: "Tramitacao");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "ProtocoloId",
                table: "ItensProcesso");

            migrationBuilder.RenameColumn(
                name: "ProcessoID",
                table: "Equipamento",
                newName: "ProcessoId");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_ProcessoID",
                table: "Equipamento",
                newName: "IX_Equipamento_ProcessoId");

            migrationBuilder.AddColumn<int>(
                name: "ProcessoId",
                table: "Tramitacao",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProcessoId",
                table: "Processo",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProcessoId",
                table: "ItensProcesso",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processo",
                table: "Processo",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacao_ProcessoId",
                table: "Tramitacao",
                column: "ProcessoId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensProcesso_ProcessoId",
                table: "ItensProcesso",
                column: "ProcessoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensProcesso_Processo_ProcessoId",
                table: "ItensProcesso",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tramitacao_Processo_ProcessoId",
                table: "Tramitacao",
                column: "ProcessoId",
                principalTable: "Processo",
                principalColumn: "ProcessoId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipamento_Processo_ProcessoId",
                table: "Equipamento");

            migrationBuilder.DropForeignKey(
                name: "FK_ItensProcesso_Processo_ProcessoId",
                table: "ItensProcesso");

            migrationBuilder.DropForeignKey(
                name: "FK_Tramitacao_Processo_ProcessoId",
                table: "Tramitacao");

            migrationBuilder.DropIndex(
                name: "IX_Tramitacao_ProcessoId",
                table: "Tramitacao");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Processo",
                table: "Processo");

            migrationBuilder.DropIndex(
                name: "IX_ItensProcesso_ProcessoId",
                table: "ItensProcesso");

            migrationBuilder.DropColumn(
                name: "ProcessoId",
                table: "Tramitacao");

            migrationBuilder.DropColumn(
                name: "ProcessoId",
                table: "Processo");

            migrationBuilder.DropColumn(
                name: "ProcessoId",
                table: "ItensProcesso");

            migrationBuilder.RenameColumn(
                name: "ProcessoId",
                table: "Equipamento",
                newName: "ProcessoID");

            migrationBuilder.RenameIndex(
                name: "IX_Equipamento_ProcessoId",
                table: "Equipamento",
                newName: "IX_Equipamento_ProcessoID");

            migrationBuilder.AddColumn<int>(
                name: "ProtocoloId",
                table: "Tramitacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Processo",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "ProtocoloId",
                table: "ItensProcesso",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Processo",
                table: "Processo",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Tramitacao_ProtocoloId",
                table: "Tramitacao",
                column: "ProtocoloId");

            migrationBuilder.CreateIndex(
                name: "IX_ItensProcesso_ProtocoloId",
                table: "ItensProcesso",
                column: "ProtocoloId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipamento_Processo_ProcessoID",
                table: "Equipamento",
                column: "ProcessoID",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ItensProcesso_Processo_ProtocoloId",
                table: "ItensProcesso",
                column: "ProtocoloId",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Tramitacao_Processo_ProtocoloId",
                table: "Tramitacao",
                column: "ProtocoloId",
                principalTable: "Processo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
