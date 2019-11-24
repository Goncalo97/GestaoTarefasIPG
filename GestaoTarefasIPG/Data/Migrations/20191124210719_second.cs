using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Data.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NivelCargo",
                table: "Cargo",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelCargo",
                table: "Cargo");
        }
    }
}
