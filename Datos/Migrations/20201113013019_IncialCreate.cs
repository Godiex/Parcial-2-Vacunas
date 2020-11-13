using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Datos.Migrations
{
    public partial class IncialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Personas",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "nvarchar(11)", nullable: false),
                    TipoDocumento = table.Column<string>(type: "nvarchar(15)", nullable: true),
                    Nombres = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    NombresAcudiente = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(14)", nullable: true),
                    NombreInstitucionEducativa = table.Column<string>(type: "nvarchar(40)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personas", x => x.Identificacion);
                });

            migrationBuilder.CreateTable(
                name: "Vacunas",
                columns: table => new
                {
                    VacunaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(11)", nullable: true),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Identificacion = table.Column<string>(type: "nvarchar(11)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vacunas", x => x.VacunaId);
                    table.ForeignKey(
                        name: "FK_Vacunas_Personas_Identificacion",
                        column: x => x.Identificacion,
                        principalTable: "Personas",
                        principalColumn: "Identificacion",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vacunas_Identificacion",
                table: "Vacunas",
                column: "Identificacion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vacunas");

            migrationBuilder.DropTable(
                name: "Personas");
        }
    }
}
