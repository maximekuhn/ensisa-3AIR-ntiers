using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace JeBalance.Architecture.Migrations
{
    public partial class adresse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "adresse",
                table: "SUSPECTS",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "addresse",
                table: "INFORMATEURS",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "calomniateur",
                table: "INFORMATEURS",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "adresse",
                table: "SUSPECTS");

            migrationBuilder.DropColumn(
                name: "addresse",
                table: "INFORMATEURS");

            migrationBuilder.DropColumn(
                name: "calomniateur",
                table: "INFORMATEURS");
        }
    }
}
