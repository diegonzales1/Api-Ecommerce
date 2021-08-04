using Dominio.Entidades;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commerce.Request
{
    public class CarrinhoRequest
    {
        [Required(ErrorMessage = "Informe o ID do Cliente! (Campo obrigatório.)")]
        public int ClienteId { get; set; }

        public IEnumerable<ItemCarrinhoRequest> ItemCarrinho { get; set; }

        [JsonIgnore]
        public Cliente Cliente { get; set; }
    }
}