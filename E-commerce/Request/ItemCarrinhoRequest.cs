using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_commerce.Request
{
    public class ItemCarrinhoRequest
    {
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
    }
}
