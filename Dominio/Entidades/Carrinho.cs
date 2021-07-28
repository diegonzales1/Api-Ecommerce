using System.Collections.Generic;

namespace Dominio.Entidades
{
    public class Carrinho : Base
    {
        public List<ItemCarrinho> ItemCarrinho { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
    }
}
