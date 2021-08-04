using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Dominio.Entidades
{
    public class Categoria : Base
    {
        public string Modelo { get; set; }
        public string Genero { get; set; }

        [JsonIgnore]
        public virtual ICollection<Produto> Produtos { get; set; }
    }
}

