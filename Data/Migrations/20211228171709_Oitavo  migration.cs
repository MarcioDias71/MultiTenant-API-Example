using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Oitavomigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaID",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_EmpresaID",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmpresaID",
                table: "Usuarios");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_ID_EMPRESA",
                table: "Usuarios",
                column: "ID_EMPRESA");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresas_ID_EMPRESA",
                table: "Usuarios",
                column: "ID_EMPRESA",
                principalTable: "Empresas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Empresas_ID_EMPRESA",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_ID_EMPRESA",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "EmpresaID",
                table: "Usuarios",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Empresas_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID",
                principalTable: "Empresas",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
