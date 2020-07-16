using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class CreateTables_User_Fortschritt_Lektion_Vokabel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lektion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lektion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fortschritt",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LektionId = table.Column<int>(type: "int", nullable: false)
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
                });

            migrationBuilder.CreateTable(
                name: "Vokabel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LektionId = table.Column<int>(type: "int", nullable: false),
                    Frz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Deu = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phonetik = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vokabel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vokabel_Lektion_LektionId",
                        column: x => x.LektionId,
                        principalTable: "Lektion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_LektionId",
                table: "Fortschritt",
                column: "LektionId");

            migrationBuilder.CreateIndex(
                name: "IX_Fortschritt_UserId",
                table: "Fortschritt",
                column: "UserId");

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
                name: "Vokabel");

            migrationBuilder.DropTable(
                name: "Lektion");
        }
    }
}
