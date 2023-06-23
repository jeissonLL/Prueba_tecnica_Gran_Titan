using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUDMascotas.Migrations
{
    public partial class v03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Raza",
                table: "Mascotas",
                newName: "raza");

            migrationBuilder.RenameColumn(
                name: "IdDueño",
                table: "Mascotas",
                newName: "iddueño");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Mascotas",
                newName: "fechanacimiento");

            migrationBuilder.RenameColumn(
                name: "Especie",
                table: "Mascotas",
                newName: "especie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "raza",
                table: "Mascotas",
                newName: "Raza");

            migrationBuilder.RenameColumn(
                name: "iddueño",
                table: "Mascotas",
                newName: "IdDueño");

            migrationBuilder.RenameColumn(
                name: "fechanacimiento",
                table: "Mascotas",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "especie",
                table: "Mascotas",
                newName: "Especie");
        }
    }
}
