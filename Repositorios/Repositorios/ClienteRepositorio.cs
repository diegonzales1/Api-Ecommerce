using Dominio.Entidades;
using Dominio.Interfaces;
using Repositorio.Contexto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Repositorios
{
 
      public  class ClienteRepositorio : BaseRepositorio<Cliente>, IClienteRepositorio
    {
       public ClienteRepositorio(BancoContexto bancoContexto) : base(bancoContexto) { }
    }
    
}
