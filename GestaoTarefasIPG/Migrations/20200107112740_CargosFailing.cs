using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class CargosFailing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NivelCargo",
                table: "Cargo");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Servico",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "NomeCargo",
                table: "Cargo",
                maxLength: 248,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Servico",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "NomeCargo",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 248);

            migrationBuilder.AddColumn<string>(
                name: "NivelCargo",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
