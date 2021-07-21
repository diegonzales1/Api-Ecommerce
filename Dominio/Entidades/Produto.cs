﻿using System;
using System.Collections.Generic;
using System.Text;

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
        public decimal Preco { get; set; }
    }
}