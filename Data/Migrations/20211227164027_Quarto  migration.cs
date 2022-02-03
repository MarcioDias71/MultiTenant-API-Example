using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Quartomigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresasConexoes_Empresas_ID_LOJA",
                table: "EmpresasConexoes");

            migrationBuilder.RenameColumn(
                name: "ID_LOJA",
                table: "EmpresasConexoes",
                newName: "ID_EMPRESA");

            migrationBuilder.RenameIndex(
                name: "IX_EmpresasConexoes_ID_LOJA",
                table: "EmpresasConexoes",
                newName: "IX_EmpresasConexoes_ID_EMPRESA");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresasConexoes_Empresas_ID_EMPRESA",
                table: "EmpresasConexoes",
                column: "ID_EMPRESA",
                principalTable: "Empresas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmpresasConexoes_Empresas_ID_EMPRESA",
                table: "EmpresasConexoes");

            migrationBuilder.RenameColumn(
                name: "ID_EMPRESA",
                table: "EmpresasConexoes",
                newName: "ID_LOJA");

            migrationBuilder.RenameIndex(
                name: "IX_EmpresasConexoes_ID_EMPRESA",
                table: "EmpresasConexoes",
                newName: "IX_EmpresasConexoes_ID_LOJA");

            migrationBuilder.AddForeignKey(
                name: "FK_EmpresasConexoes_Empresas_ID_LOJA",
                table: "EmpresasConexoes",
                column: "ID_LOJA",
                principalTable: "Empresas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
