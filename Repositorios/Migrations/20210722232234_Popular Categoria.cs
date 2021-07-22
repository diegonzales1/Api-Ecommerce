using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class PopularCategoria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categorias (Modelo, Categorias) VALUES ('Casual', 'Feminino');");
            migrationBuilder.Sql("INSERT INTO Categorias (Modelo, Categorias) VALUES ('Casual', 'Masculino');");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
