using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Infrastructure.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "INFORMATEURS",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    calomniateur = table.Column<bool>(type: "INTEGER", nullable: false),
                    adresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INFORMATEURS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "REPONSES",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type_reponse = table.Column<int>(type: "int", nullable: false),
                    retribution = table.Column<double>(type: "REAL", nullable: true),
                    horodatage = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_REPONSES", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "SUSPECTS",
                columns: table => new
                {
                    id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    nom = table.Column<string>(type: "TEXT", nullable: false),
                    prenom = table.Column<string>(type: "TEXT", nullable: false),
                    adresse = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SUSPECTS", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "DENONCIATIONS",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "TEXT", nullable: false),
                    type_delit = table.Column<int>(type: "int", nullable: false),
                    pays_evasion = table.Column<string>(type: "TEXT", nullable: true),
                    statut = table.Column<int>(type: "int", nullable: false),
                    horodatage = table.Column<DateTime>(type: "TEXT", nullable: false),
                    fk_informateur = table.Column<int>(type: "INTEGER", nullable: false),
                    fk_suspect = table.Column<int>(type: "INTEGER", nullable: false),
                    fk_reponse = table.Column<int>(type: "INTEGER", nullable: true),
                    InformateurId = table.Column<int>(type: "INTEGER", nullable: false),
                    SuspectId = table.Column<int>(type: "INTEGER", nullable: false),
                    ReponseId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DENONCIATIONS", x => x.id);
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_INFORMATEURS_fk_informateur",
                        column: x => x.fk_informateur,
                        principalTable: "INFORMATEURS",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_REPONSES_fk_reponse",
                        column: x => x.fk_reponse,
                        principalTable: "REPONSES",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_DENONCIATIONS_SUSPECTS_fk_suspect",
                        column: x => x.fk_suspect,
                        principalTable: "SUSPECTS",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_informateur",
                table: "DENONCIATIONS",
                column: "fk_informateur");

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_reponse",
                table: "DENONCIATIONS",
                column: "fk_reponse",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DENONCIATIONS_fk_suspect",
                table: "DENONCIATIONS",
                column: "fk_suspect");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DENONCIATIONS");

            migrationBuilder.DropTable(
                name: "INFORMATEURS");

            migrationBuilder.DropTable(
                name: "REPONSES");

            migrationBuilder.DropTable(
                name: "SUSPECTS");
        }
    }
}
