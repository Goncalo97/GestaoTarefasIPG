using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class FixFuncionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "telemovel",
                table: "Funcionario",
                newName: "Telemovel");

            migrationBuilder.RenameColumn(
                name: "nome",
                table: "Funcionario",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "email",
                table: "Funcionario",
                newName: "Email");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Telemovel",
                table: "Funcionario",
                newName: "telemovel");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "Funcionario",
                newName: "nome");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Funcionario",
                newName: "email");
        }
    }
}
