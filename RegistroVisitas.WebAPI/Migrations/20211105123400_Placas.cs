using Microsoft.EntityFrameworkCore.Migrations;

namespace RegistroVisitas.WebAPI.Migrations
{
    public partial class Placas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Placas",
                table: "Visitas",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placas",
                table: "Visitas");
        }
    }
}
