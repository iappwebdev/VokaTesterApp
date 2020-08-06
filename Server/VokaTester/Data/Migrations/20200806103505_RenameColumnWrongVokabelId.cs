using Microsoft.EntityFrameworkCore.Migrations;

namespace VokaTester.Data.Migrations
{
    public partial class RenameColumnWrongVokabelId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fortschritt_Vokabel_LetzteVokabelIdWrong",
                table: "Fortschritt");

            migrationBuilder.RenameColumn(
                name: "LetzteVokabelIdWrong",
                table: "Fortschritt",
                newName: "LetzteVokabelWrongId");

            migrationBuilder.RenameIndex(
                name: "IX_Fortschritt_LetzteVokabelIdWrong",
                table: "Fortschritt",
                newName: "IX_Fortschritt_LetzteVokabelWrongId");

            migrationBuilder.AddForeignKey(
                name: "FK_Fortschritt_Vokabel_LetzteVokabelWrongId",
                table: "Fortschritt",
                column: "LetzteVokabelWrongId",
                principalTable: "Vokabel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fortschritt_Vokabel_LetzteVokabelWrongId",
                table: "Fortschritt");

            migrationBuilder.RenameColumn(
                name: "LetzteVokabelWrongId",
                table: "Fortschritt",
                newName: "LetzteVokabelIdWrong");

            migrationBuilder.RenameIndex(
                name: "IX_Fortschritt_LetzteVokabelWrongId",
                table: "Fortschritt",
                newName: "IX_Fortschritt_LetzteVokabelIdWrong");

            migrationBuilder.AddForeignKey(
                name: "FK_Fortschritt_Vokabel_LetzteVokabelIdWrong",
                table: "Fortschritt",
                column: "LetzteVokabelIdWrong",
                principalTable: "Vokabel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
