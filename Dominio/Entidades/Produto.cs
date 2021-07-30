using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Produto : Base
    {
        public string Nome { get; set; }
        public string Unidade { get; set; }
        public string Marca { get; set; }
        public string Cor { get; set; }
        public string Descricao { get; set; }
        public int Tamanho { get; set; }
        public int Quantidade { get; set; }
        public int CategoriaId { get; set; }
        public decimal Preco { get; set; }
        public virtual Categoria Categoria { get; set; }

       [JsonIgnore]
       public virtual ItemCarrinho Itens { get; set; }

    }
}
