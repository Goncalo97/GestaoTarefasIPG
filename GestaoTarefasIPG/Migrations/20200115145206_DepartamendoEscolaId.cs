using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class DepartamendoEscolaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "role",
                table: "Cargo");

            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Departamento",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Departamento_EscolaId",
                table: "Departamento",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Departamento_Escola_EscolaId",
                table: "Departamento",
                column: "EscolaId",
                principalTable: "Escola",
                principalColumn: "EscolaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departamento_Escola_EscolaId",
                table: "Departamento");

            migrationBuilder.DropIndex(
                name: "IX_Departamento_EscolaId",
                table: "Departamento");

            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Departamento");

            migrationBuilder.AddColumn<string>(
                name: "role",
                table: "Cargo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
