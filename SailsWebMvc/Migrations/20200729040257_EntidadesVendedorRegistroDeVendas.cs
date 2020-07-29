using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesWebMvc.Migrations
{
    public partial class EntidadesVendedorRegistroDeVendas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vendedor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    SalarioBase = table.Column<double>(nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false),
                    DepartmentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendedor", x => x.id);
                    table.ForeignKey(
                        name: "FK_Vendedor_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RegistroDeVenda",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Data = table.Column<DateTime>(nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Vendedorid = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegistroDeVenda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RegistroDeVenda_Vendedor_Vendedorid",
                        column: x => x.Vendedorid,
                        principalTable: "Vendedor",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RegistroDeVenda_Vendedorid",
                table: "RegistroDeVenda",
                column: "Vendedorid");

            migrationBuilder.CreateIndex(
                name: "IX_Vendedor_DepartmentId",
                table: "Vendedor",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegistroDeVenda");

            migrationBuilder.DropTable(
                name: "Vendedor");
        }
    }
}
