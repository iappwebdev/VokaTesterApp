using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class ExtenTestResultForArtikelFehler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsArtikelFehler",
                table: "TestResult",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSimilarAndArtikelFehler",
                table: "TestResult",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsArtikelFehler",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "IsSimilarAndArtikelFehler",
                table: "TestResult");
        }
    }
}
