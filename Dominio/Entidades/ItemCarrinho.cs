using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class ItemCarrinho : Base
    {
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }
        public virtual Carrinho Carrinho { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
