using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace back_wachify.Migrations
{
    public partial class PackCrud : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Abonnements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAbonnement = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Abonnements", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pack",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Durations = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AbonnementId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pack_Abonnements_AbonnementId",
                        column: x => x.AbonnementId,
                        principalTable: "Abonnements",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pack_AbonnementId",
                table: "Pack",
                column: "AbonnementId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pack");
            migrationBuilder.DropTable(
                name: "Abonnements");
        }
    }
}
