using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class updateec : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_FilmId",
                table: "Commantire");

            migrationBuilder.DropColumn(
                name: "FilmId",
                table: "Commantire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FilmId",
                table: "Commantire",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_FilmId",
                table: "Commantire",
                column: "FilmId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id");
        }
    }
}
