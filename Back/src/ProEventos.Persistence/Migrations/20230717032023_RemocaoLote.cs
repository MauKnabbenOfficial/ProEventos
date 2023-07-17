using Microsoft.EntityFrameworkCore.Migrations;

namespace ProEventos.Persistence.Migrations
{
    public partial class RemocaoLote : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Eventos_EventoId",
                table: "RedeSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais");

            migrationBuilder.DropColumn(
                name: "Lote",
                table: "Eventos");

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Eventos_EventoId",
                table: "RedeSociais",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Eventos_EventoId",
                table: "RedeSociais");

            migrationBuilder.DropForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais");

            migrationBuilder.AddColumn<string>(
                name: "Lote",
                table: "Eventos",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Eventos_EventoId",
                table: "RedeSociais",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RedeSociais_Palestrantes_PalestranteId",
                table: "RedeSociais",
                column: "PalestranteId",
                principalTable: "Palestrantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
