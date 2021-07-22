using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class Categoria : Base
    {
        public string Modelo { get; set; }
        public string Categorias { get; set; }
        public virtual List<Produto> Produtos { get; set; }
    }
}

