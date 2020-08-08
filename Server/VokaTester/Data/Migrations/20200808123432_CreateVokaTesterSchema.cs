using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class CreateVokaTesterSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bereich",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Abkuerzung = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    Key = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
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
                    PositionLektion = table.Column<int>(type: "int", nullable: false),
                    PositionBereich = table.Column<int>(type: "int", nullable: false),
                    CaseSensitive = table.Column<bool>(type: "bit", nullable: false),
                    Frz = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    FrzSan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Phonetik = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Deu = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DeuSan = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
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

            migrationBuilder.CreateTable(
                name: "Fortschritt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LektionId = table.Column<int>(type: "int", nullable: false),
                    BereichId = table.Column<int>(type: "int", nullable: true),
                    Durchlauf = table.Column<int>(type: "int", nullable: false),
                    LetzteVokabelCorrectId = table.Column<int>(type: "int", nullable: true),
                    LetzteVokabelWrongId = table.Column<int>(type: "int", nullable: true),
                    DateTestedLast = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fortschritt", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fortschritt_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fortschritt_Bereich_BereichId",
                        column: x => x.BereichId,
                        principalTable: "Bereich",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fortschritt_Lektion_LektionId",
                        column: x => x.LektionId,
                        principalTable: "Lektion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fortschritt_Vokabel_LetzteVokabelCorrectId",
                        column: x => x.LetzteVokabelCorrectId,
                        principalTable: "Vokabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fortschritt_Vokabel_LetzteVokabelWrongId",
                        column: x => x.LetzteVokabelWrongId,
                        principalTable: "Vokabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TestResult",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VokabelId = table.Column<int>(type: "int", nullable: false),
                    Truth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsSimilar = table.Column<bool>(type: "bit", nullable: false),
                    IsArtikelFehler = table.Column<bool>(type: "bit", nullable: false),
                    IsSimilarAndArtikelFehler = table.Column<bool>(type: "bit", nullable: false),
                    IsWrong = table.Column<bool>(type: "bit", nullable: false),
                    DateTested = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TestResult", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TestResult_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TestResult_Vokabel_VokabelId",
                        column: x => x.VokabelId,
                        principalTable: "Vokabel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_BereichId",
                table: "Fortschritt",
                column: "BereichId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LektionId",
                table: "Fortschritt",
                column: "LektionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LetzteVokabelCorrectId",
                table: "Fortschritt",
                column: "LetzteVokabelCorrectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LetzteVokabelWrongId",
                table: "Fortschritt",
                column: "LetzteVokabelWrongId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_UserId",
                table: "Fortschritt",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_UserId",
                table: "TestResult",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TestResult_VokabelId",
                table: "TestResult",
                column: "VokabelId");

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
                name: "Fortschritt");

            migrationBuilder.DropTable(
                name: "TestResult");

            migrationBuilder.DropTable(
                name: "Vokabel");

            migrationBuilder.DropTable(
                name: "Bereich");

            migrationBuilder.DropTable(
                name: "Lektion");
        }
    }
}
