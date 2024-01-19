using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Architecture.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "app");

            migrationBuilder.CreateTable(
                name: "DENONCIATIONS",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type_delit = table.Column<int>(type: "int", nullable: false),
                    pays_evasion = table.Column<string>(type: "TEXT", nullable: true),
                    statut = table.Column<int>(type: "int", nullable: false),
                    id_informateur = table.Column<int>(type: "INTEGER", nullable: false),
                    id_suspect = table.Column<int>(type: "INTEGER", nullable: false),
                    horodatage = table.Column<DateTime>(type: "TEXT", nullable: false),
                    id_reponse = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENONCIATIONS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "INFORMATEURS",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFORMATEURS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SUSPECTS",
                schema: "app",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUSPECTS", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENONCIATIONS",
                schema: "app");

            migrationBuilder.DropTable(
                name: "INFORMATEURS",
                schema: "app");

            migrationBuilder.DropTable(
                name: "SUSPECTS",
                schema: "app");
        }
    }
}
