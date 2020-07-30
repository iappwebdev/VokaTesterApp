using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class CreateVokabelSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bereich",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bereich", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lektion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nr = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Titel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    SubTitel = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Inhalt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lektion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vokabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SheetNr = table.Column<int>(type: "int", nullable: false),
                    LektionId = table.Column<int>(type: "int", nullable: false),
                    BereichId = table.Column<int>(type: "int", nullable: false),
                    CaseSensitive = table.Column<bool>(type: "bit", nullable: false),
                    Frz = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FrzSan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phonetik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeuSan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Wortnetze = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vokabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vokabel_Bereich_BereichId",
                        column: x => x.BereichId,
                        principalTable: "Bereich",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Vokabel_Lektion_LektionId",
                        column: x => x.LektionId,
                        principalTable: "Lektion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vokabel_BereichId",
                table: "Vokabel",
                column: "BereichId");

            migrationBuilder.CreateIndex(
                name: "IX_Vokabel_LektionId",
                table: "Vokabel",
                column: "LektionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vokabel");

            migrationBuilder.DropTable(
                name: "Bereich");

            migrationBuilder.DropTable(
                name: "Lektion");
        }
    }
}
