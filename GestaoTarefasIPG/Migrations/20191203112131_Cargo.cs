﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace GestaoTarefasIPG.Migrations
{
    public partial class Cargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cargo",
                columns: table => new
                {
                    CargoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCargo = table.Column<string>(nullable: false),
                    NivelCargo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargo", x => x.CargoID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cargo");
        }
    }
}
