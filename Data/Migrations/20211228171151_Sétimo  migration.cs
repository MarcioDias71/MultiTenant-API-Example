using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Sétimomigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmpresasConexoes_ID_EMPRESA",
                table: "EmpresasConexoes");

            migrationBuilder.AddColumn<int>(
                name: "ID_EMPRESA",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasConexoes_ID_EMPRESA",
                table: "EmpresasConexoes",
                column: "ID_EMPRESA",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmpresasConexoes_ID_EMPRESA",
                table: "EmpresasConexoes");

            migrationBuilder.DropColumn(
                name: "ID_EMPRESA",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_EmpresasConexoes_ID_EMPRESA",
                table: "EmpresasConexoes",
                column: "ID_EMPRESA");
        }
    }
}
