using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
  public  class Carrinho : Base
    {
        public string Produto  { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public int ProdutoId { get; set; }
    }
}
