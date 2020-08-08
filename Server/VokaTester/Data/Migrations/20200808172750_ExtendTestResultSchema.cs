using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class ExtendTestResultSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AnswerSan",
                table: "TestResult",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Question",
                table: "TestResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "TruthSan",
                table: "TestResult",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AnswerSan",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "Question",
                table: "TestResult");

            migrationBuilder.DropColumn(
                name: "TruthSan",
                table: "TestResult");
        }
    }
}
