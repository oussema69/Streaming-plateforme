using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class tablecommentaire : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Commantire",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    IdFilm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commantire", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Commantire_Film_IdFilm",
                        column: x => x.IdFilm,
                        principalTable: "Film",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Commantire_User_IdUser",
                        column: x => x.IdUser,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_IdFilm",
                table: "Commantire",
                column: "IdFilm");

            migrationBuilder.CreateIndex(
                name: "IX_Commantire_IdUser",
                table: "Commantire",
                column: "IdUser");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Commantire");
        }
    }
}
