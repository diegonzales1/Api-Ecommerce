using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
  public  class CategoriaRepositorio : BaseRepositorio<Categoria>, ICategoriaRepositorio
    {
        public CategoriaRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }
}
