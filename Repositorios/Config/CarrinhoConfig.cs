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
            builder.Property(c => c.Cliente).IsRequired();
            builder.Property(c => c.ClienteId).IsRequired();
            builder.Property(c => c.ItemCarrinho).IsRequired();
        }
    }
}