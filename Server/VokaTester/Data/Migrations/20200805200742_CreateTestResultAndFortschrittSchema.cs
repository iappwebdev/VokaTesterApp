using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class CreateTestResultAndFortschrittSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FehlerArt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Truth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FehlerArt", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fortschritt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LektionId = table.Column<int>(type: "int", nullable: false),
                    Durchlauf = table.Column<int>(type: "int", nullable: false),
                    LetzteVokabelCorrectId = table.Column<int>(type: "int", nullable: true),
                    LetzteVokabelIdWrong = table.Column<int>(type: "int", nullable: true)
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
                        name: "FK_Fortschritt_Vokabel_LetzteVokabelIdWrong",
                        column: x => x.LetzteVokabelIdWrong,
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
                    VokabelId = table.Column<int>(type: "int", nullable: false),
                    Truth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsCorrect = table.Column<bool>(type: "bit", nullable: false),
                    IsSimilar = table.Column<bool>(type: "bit", nullable: false),
                    IsWrong = table.Column<bool>(type: "bit", nullable: false)
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
                name: "IX_Fortschritt_LektionId",
                table: "Fortschritt",
                column: "LektionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LetzteVokabelCorrectId",
                table: "Fortschritt",
                column: "LetzteVokabelCorrectId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LetzteVokabelIdWrong",
                table: "Fortschritt",
                column: "LetzteVokabelIdWrong");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FehlerArt");

            migrationBuilder.DropTable(
                name: "Fortschritt");

            migrationBuilder.DropTable(
                name: "TestResult");
        }
    }
}
