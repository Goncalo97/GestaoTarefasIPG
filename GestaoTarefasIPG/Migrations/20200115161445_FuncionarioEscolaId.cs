using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class FuncionarioEscolaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EscolaId",
                table: "Funcionario",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Funcionario_EscolaId",
                table: "Funcionario",
                column: "EscolaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_Escola_EscolaId",
                table: "Funcionario",
                column: "EscolaId",
                principalTable: "Escola",
                principalColumn: "EscolaID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_Escola_EscolaId",
                table: "Funcionario");

            migrationBuilder.DropIndex(
                name: "IX_Funcionario_EscolaId",
                table: "Funcionario");

            migrationBuilder.DropColumn(
                name: "EscolaId",
                table: "Funcionario");
        }
    }
}
