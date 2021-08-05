using System.Collections.Generic;

namespace E_commerce.Response
{
    public class ProdutoResponse
    {
        public string NomeProduto { get; set; }
        public string UnidadeProduto { get; set; }
        public string MarcaProduto { get; set; }
        public string CorProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public int TamanhoProduto { get; set; }
        public int QuantidadeProduto { get; set; }
        public int CategoriaId { get; set; }
        public decimal PrecoProduto { get; set; }
        public string ModeloProduto { get; set; }
        public string GeneroProduto { get; set; }
    }
}
