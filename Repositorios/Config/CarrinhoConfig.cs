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
            builder.Property(c => c.ClienteId).IsRequired();
            //builder.Property(c => c.ValorTotal).HasPrecision(18, 4).IsRequired();
            builder.HasOne(c => c.Cliente).WithMany(ca => ca.Carrinhos);
            builder.HasMany(i => i.Itens).WithOne(c => c.Carrinho);
        }
    }
}