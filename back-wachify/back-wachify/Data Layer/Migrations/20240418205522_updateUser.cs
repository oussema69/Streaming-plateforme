using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class updateUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pack_Abonnements_AbonnementId",
                table: "Pack");

            migrationBuilder.DropIndex(
                name: "IX_Pack_AbonnementId",
                table: "Pack");

            migrationBuilder.DropColumn(
                name: "AbonnementId",
                table: "Pack");

            migrationBuilder.AddColumn<int>(
                name: "Etat",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "secretCode",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PackId",
                table: "Abonnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Abonnements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_PackId",
                table: "Abonnements",
                column: "PackId");

            migrationBuilder.CreateIndex(
                name: "IX_Abonnements_UserId",
                table: "Abonnements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnements_Pack_PackId",
                table: "Abonnements",
                column: "PackId",
                principalTable: "Pack",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Abonnements_User_UserId",
                table: "Abonnements",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Abonnements_Pack_PackId",
                table: "Abonnements");

            migrationBuilder.DropForeignKey(
                name: "FK_Abonnements_User_UserId",
                table: "Abonnements");

            migrationBuilder.DropIndex(
                name: "IX_Abonnements_PackId",
                table: "Abonnements");

            migrationBuilder.DropIndex(
                name: "IX_Abonnements_UserId",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "Etat",
                table: "User");

            migrationBuilder.DropColumn(
                name: "secretCode",
                table: "User");

            migrationBuilder.DropColumn(
                name: "PackId",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Abonnements");

            migrationBuilder.AddColumn<int>(
                name: "AbonnementId",
                table: "Pack",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pack_AbonnementId",
                table: "Pack",
                column: "AbonnementId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pack_Abonnements_AbonnementId",
                table: "Pack",
                column: "AbonnementId",
                principalTable: "Abonnements",
                principalColumn: "Id");
        }
    }
}
