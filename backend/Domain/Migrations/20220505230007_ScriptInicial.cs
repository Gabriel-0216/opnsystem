using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Dominio.Migrations
{
    public partial class ScriptInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "[Departamento]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeDepartamento = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    Data_Criacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Departamento]", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "[Sugestoes]",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeColaborador = table.Column<string>(type: "varchar(256)", maxLength: 256, nullable: false),
                    DepartamentoId = table.Column<int>(type: "int", nullable: false),
                    TextoSugestao = table.Column<string>(type: "TEXT", nullable: false),
                    Justificativa = table.Column<string>(type: "TEXT", nullable: false),
                    Data_Criacao = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Data_Atualizacao = table.Column<DateTime>(type: "DATETIME", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_[Sugestoes]", x => x.Id);
                    table.ForeignKey(
                        name: "FK_[Sugestoes]_[Departamento]_DepartamentoId",
                        column: x => x.DepartamentoId,
                        principalTable: "[Departamento]",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_[Sugestoes]_DepartamentoId",
                table: "[Sugestoes]",
                column: "DepartamentoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "[Sugestoes]");

            migrationBuilder.DropTable(
                name: "[Departamento]");
        }
    }
}
