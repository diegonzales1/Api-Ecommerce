using Dominio.Entidades;
using System.Collections.Generic;

namespace E_commerce.Request
{
    public class CarrinhoRequest
    {
        public List<ItemCarrinho> ItemCarrinho { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}