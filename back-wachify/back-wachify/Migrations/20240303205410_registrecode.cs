using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class registrecode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Utilisateur",
                newName: "utilisateurs");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmationCode",
                table: "User",
                type: "nvarchar(5)",
                maxLength: 5,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsEmailConfirmed",
                table: "User",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "UtilisateurId",
                table: "utilisateurs",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Nom",
                table: "utilisateurs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_utilisateurs",
                table: "utilisateurs",
                column: "UtilisateurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_utilisateurs",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "ConfirmationCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsEmailConfirmed",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UtilisateurId",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "utilisateurs");

            migrationBuilder.DropColumn(
                name: "Nom",
                table: "utilisateurs");

            migrationBuilder.RenameTable(
                name: "utilisateurs",
                newName: "Utilisateur");
        }
    }
}
