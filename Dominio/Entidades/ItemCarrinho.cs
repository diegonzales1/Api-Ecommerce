using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio.Entidades
{
    public class ItemCarrinho : Base
    {
        public Produto Produto { get; set; }
        public int Quantidade { get; set; }
    }
}
