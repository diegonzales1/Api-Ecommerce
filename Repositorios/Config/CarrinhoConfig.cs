using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class CarrinhoConfig : IEntityTypeConfiguration<Carrinho>
    {
        public void Configure(EntityTypeBuilder<Carrinho> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Cliente).WithMany(ca => ca.Carrinhos);
            builder.HasMany(i => i.Itens).WithOne(c => c.Carrinho);
            builder.HasOne(c => c.Cliente).WithMany(c => c.Carrinhos);
           
        }
    }
}