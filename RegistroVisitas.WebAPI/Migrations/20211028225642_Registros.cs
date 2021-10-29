using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroVisitas.WebAPI.Migrations
{
    public partial class Registros : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Visitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Recepcionista = table.Column<string>(type: "TEXT", nullable: true),
                    CasaId = table.Column<string>(type: "TEXT", nullable: true),
                    NumeroDePase = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraDeEntrada = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Visitante = table.Column<string>(type: "TEXT", nullable: true),
                    Notas = table.Column<string>(type: "TEXT", nullable: true),
                    Foto = table.Column<string>(type: "TEXT", nullable: true),
                    FechaHoraDeSalida = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visitas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Visitas");
        }
    }
}
