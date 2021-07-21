using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
   public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
    {
        public ProdutoRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }
}
