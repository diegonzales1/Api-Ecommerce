using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Repositorio.Config;

namespace Repositorio.Contexto
{
    public class BancoContexto : DbContext
    {
        DbSet<Produto> Produtos { get; set; }
        DbSet<Categoria> Categorias { get; set; }
        DbSet<Cliente> Clientes { get; set; }
        DbSet<Carrinho> Carrinhos { get; set; }

        public BancoContexto(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(BancoContexto).Assembly);
            modelBuilder
                .ApplyConfiguration(new ProdutoConfig())
                .ApplyConfiguration(new CarrinhoConfig())
                .ApplyConfiguration(new CategoriaConfig())
                .ApplyConfiguration(new ClienteConfig());
        }

    }
}