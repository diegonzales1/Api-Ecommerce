using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Carrinho : Base
    {
        [JsonIgnore]
        public virtual Cliente Cliente { get; set; }

        public int ClienteId { get; set; }

        [JsonIgnore]
        public virtual ICollection<ItemCarrinho> Itens { get; set; }
    }
}
