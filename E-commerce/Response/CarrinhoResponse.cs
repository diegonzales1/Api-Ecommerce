using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Response
{
    public class CarrinhoResponse
    {
        public string NomeCliente { get; set; }
        public List<string> NomeProduto { get; set; }
    }
}
