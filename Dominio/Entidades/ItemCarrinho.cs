using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class ItemCarrinho : Base
    {
        public int Quantidade { get; set; }
        public int ProdutoId { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produto { get; set; }

        [JsonIgnore]
        public virtual Carrinho Carrinho { get; set; }
    }
}
