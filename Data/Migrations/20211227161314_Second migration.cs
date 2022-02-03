using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Secondmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmpresasConexoes_ID_LOJA",
                table: "EmpresasConexoes");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasConexoes_ID_LOJA",
                table: "EmpresasConexoes",
                column: "ID_LOJA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmpresasConexoes_ID_LOJA",
                table: "EmpresasConexoes");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasConexoes_ID_LOJA",
                table: "EmpresasConexoes",
                column: "ID_LOJA",
                unique: true);
        }
    }
}
