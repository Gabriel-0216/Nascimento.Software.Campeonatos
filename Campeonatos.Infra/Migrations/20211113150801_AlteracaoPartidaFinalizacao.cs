using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Campeonatos.Infra.Migrations
{
    public partial class AlteracaoPartidaFinalizacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GolsMandante",
                table: "PartidaFinalizacao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "GolsVisitante",
                table: "PartidaFinalizacao",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GolsMandante",
                table: "PartidaFinalizacao");

            migrationBuilder.DropColumn(
                name: "GolsVisitante",
                table: "PartidaFinalizacao");
        }
    }
}
