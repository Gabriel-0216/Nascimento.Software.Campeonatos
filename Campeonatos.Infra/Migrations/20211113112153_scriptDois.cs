using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Campeonatos.Infra.Migrations
{
    public partial class scriptDois : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Amarelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    QtdeAmarelos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amarelos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Amarelos_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Artilharia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    Gols = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artilharia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artilharia_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assistencias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    QtdeAssistencias = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assistencias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Assistencias_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vermelhos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogadorId = table.Column<int>(type: "int", nullable: false),
                    QtdeVermelhos = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vermelhos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vermelhos_Jogadores_JogadorId",
                        column: x => x.JogadorId,
                        principalTable: "Jogadores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Amarelos_JogadorId",
                table: "Amarelos",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Artilharia_JogadorId",
                table: "Artilharia",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Assistencias_JogadorId",
                table: "Assistencias",
                column: "JogadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Vermelhos_JogadorId",
                table: "Vermelhos",
                column: "JogadorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Amarelos");

            migrationBuilder.DropTable(
                name: "Artilharia");

            migrationBuilder.DropTable(
                name: "Assistencias");

            migrationBuilder.DropTable(
                name: "Vermelhos");
        }
    }
}
