using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RegistroVisitas.WebAPI.Migrations
{
    public partial class Recepcionistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RecepcionistaDeSalida",
                table: "Visitas",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Recepcionistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: true),
                    Codigo = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepcionistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sesiones",
                columns: table => new
                {
                    Numero = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Recepcionista = table.Column<string>(type: "TEXT", nullable: true),
                    Fecha = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sesiones", x => x.Numero);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Visitas_FechaHoraDeEntrada",
                table: "Visitas",
                column: "FechaHoraDeEntrada");

            migrationBuilder.CreateIndex(
                name: "IX_Recepcionistas_Nombre_Codigo",
                table: "Recepcionistas",
                columns: new[] { "Nombre", "Codigo" });

            migrationBuilder.CreateIndex(
                name: "IX_Sesiones_Fecha",
                table: "Sesiones",
                column: "Fecha");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recepcionistas");

            migrationBuilder.DropTable(
                name: "Sesiones");

            migrationBuilder.DropIndex(
                name: "IX_Visitas_FechaHoraDeEntrada",
                table: "Visitas");

            migrationBuilder.DropColumn(
                name: "RecepcionistaDeSalida",
                table: "Visitas");
        }
    }
}
