using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class avance6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdPersona",
                table: "Usuarios",
                newName: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Identificacion",
                table: "Usuarios",
                newName: "IdPersona");
        }
    }
}
