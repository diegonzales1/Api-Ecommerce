using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class PopularProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, CategoriaId, Preco) VALUES ('Air force', 'Qtd', 'Nike', 'Rosa', 'Confortavel', 35, 5,1, 549.99);");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, CategoriaId, Preco) VALUES ('Air force', 'Qtd', 'Nike', 'Preto', 'Confortavel', 41, 5, 1,549.99);");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, CategoriaId, Preco) VALUES ('AirMax', 'Qtd', 'Nike', 'Preto', 'Confortavel', 38, 5,1, 600.99);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
