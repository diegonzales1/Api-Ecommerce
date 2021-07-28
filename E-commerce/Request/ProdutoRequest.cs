namespace E_commerce.Request
{
    public class ProdutoRequest
    {
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
    }
}