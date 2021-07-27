using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositorio.Contexto
{
    public class BancoContexto : DbContext
    {
        DbSet<Produto> Produtos { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Carrinho> Carrinhos { get; set; }
        public BancoContexto(DbContextOptions options) : base(options) { }
    }
}
