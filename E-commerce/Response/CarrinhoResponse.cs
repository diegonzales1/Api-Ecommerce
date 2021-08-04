using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Response
{
    public class CarrinhoResponse
    {
        public string NomeCliente { get; set; }
        public string CPFCNPJCliente { get; set; }
        public List<int> QuantidadeProduto { get; set; }
        public List<string> NomeProduto { get; set; }
        public List<string> MarcaProduto { get; set; }
        public List<string> CorProduto { get; set; }
        public List<int> TamanhoProduto { get; set; }
    }
}
