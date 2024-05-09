using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class updatee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire");

            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_User_UserId",
                table: "Commantire");

            migrationBuilder.DropIndex(
                name: "IX_Commantire_UserId",
                table: "Commantire");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Commantire",
                newName: "IdUser");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Commantire",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "IdFilm",
                table: "Commantire",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire",
                column: "FilmId",
                principalTable: "Film",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire");

            migrationBuilder.DropColumn(
                name: "IdFilm",
                table: "Commantire");

            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "Commantire",
                newName: "UserId");

            migrationBuilder.AlterColumn<int>(
                name: "FilmId",
                table: "Commantire",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_UserId",
                table: "Commantire",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commantire_Film_FilmId",
                table: "Commantire",
                column: "FilmId",
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
    }
}
