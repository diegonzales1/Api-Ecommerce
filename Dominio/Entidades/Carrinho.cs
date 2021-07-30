using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Carrinho : Base
    {
        public Cliente Cliente { get; set; }

        public ItemCarrinho ItemCarrinho { get; set; }

        [JsonIgnore]
        public int ClienteId { get; set; }

        [JsonIgnore]
        public virtual List<ItemCarrinho> Itens { get; set; }
    }
}
