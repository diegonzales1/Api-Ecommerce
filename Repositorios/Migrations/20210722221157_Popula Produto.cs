using Microsoft.EntityFrameworkCore.Migrations;

namespace Repositorio.Migrations
{
    public partial class PopulaProduto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, Preco) VALUES ('Air force', 'Qtd', 'Nike', 'Rosa', 'feminino', 35, 5, 549.99);");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, Preco) VALUES ('Air force', 'Qtd', 'Nike', 'Preto', 'masculino', 41, 5, 549.99);");
            migrationBuilder.Sql("INSERT INTO Produtos (Nome, Unidade,Marca, Cor, Descricao, Tamanho, Quantidade, Preco) VALUES ('AirMax', 'Qtd', 'Nike', 'Preto', 'masculino', 38, 5, 600.99);");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
