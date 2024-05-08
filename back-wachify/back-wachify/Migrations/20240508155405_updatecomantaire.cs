using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class updatecomantaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Commantire",
                newName: "filmid");

            migrationBuilder.RenameColumn(
                name: "IdFilm",
                table: "Commantire",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_filmid",
                table: "Commantire",
                column: "filmid");

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_UserId",
                table: "Commantire",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_Film_filmid",
                table: "Commantire",
                column: "filmid",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_User_UserId",
                table: "Commantire",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_Film_filmid",
                table: "Commantire");

            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_User_UserId",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_filmid",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_UserId",
                table: "Commantire");

            migrationBuilder.RenameColumn(
                name: "filmid",
                table: "Commantire",
                newName: "IdUser");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Commantire",
                newName: "IdFilm");
        }
    }
}
