using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{ 
     public   class CarrinhoRepositorio : BaseRepositorio<Carrinho>, ICarrinhoRepositorio
    {
            public CarrinhoRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
        }
    
}
