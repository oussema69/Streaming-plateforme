using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_Film_IdFilm",
                table: "Commantire");

            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_User_IdUser",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_IdFilm",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_IdUser",
                table: "Commantire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Commantire_IdFilm",
                table: "Commantire",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_IdUser",
                table: "Commantire",
                column: "IdUser");

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_Film_IdFilm",
                table: "Commantire",
                column: "IdFilm",
                principalTable: "Film",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_User_IdUser",
                table: "Commantire",
                column: "IdUser",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
