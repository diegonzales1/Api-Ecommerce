using Dominio.Entidades;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace E_commerce.Request
{
    public class CarrinhoRequest
    {
        public int ClienteId { get; set; }
        public List<ItemCarrinho> ItemCarrinho { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}