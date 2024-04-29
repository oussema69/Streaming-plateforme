using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class upgrade : Migration
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

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Film",
                newName: "Titre");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateDeSortie",
                table: "Film",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Duree",
                table: "Film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsFree",
                table: "Film",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "LogoFilePath",
                table: "Film",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Film",
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
                name: "DateDeSortie",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "Duree",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "IsFree",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "LogoFilePath",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Film");

            migrationBuilder.DropColumn(
                name: "PackId",
                table: "Abonnements");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Abonnements");

            migrationBuilder.RenameColumn(
                name: "Titre",
                table: "Film",
                newName: "Name");

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
