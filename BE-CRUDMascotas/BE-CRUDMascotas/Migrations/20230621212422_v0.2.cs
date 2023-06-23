using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BE_CRUDMascotas.Migrations
{
    public partial class v02 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Mascotas");

            migrationBuilder.RenameColumn(
                name: "Peso",
                table: "Mascotas",
                newName: "IdDueño");

            migrationBuilder.RenameColumn(
                name: "FechaCreacion",
                table: "Mascotas",
                newName: "FechaNacimiento");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Mascotas",
                newName: "Especie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdDueño",
                table: "Mascotas",
                newName: "Peso");

            migrationBuilder.RenameColumn(
                name: "FechaNacimiento",
                table: "Mascotas",
                newName: "FechaCreacion");

            migrationBuilder.RenameColumn(
                name: "Especie",
                table: "Mascotas",
                newName: "Color");

            migrationBuilder.AddColumn<int>(
                name: "Edad",
                table: "Mascotas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
