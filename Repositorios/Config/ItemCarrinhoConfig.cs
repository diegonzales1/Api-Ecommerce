using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ItemCarrinhoConfig : IEntityTypeConfiguration<ItemCarrinho>
    {
        public void Configure(EntityTypeBuilder<ItemCarrinho> builder)
        {
            builder.HasKey(i => i.Id);
            builder.HasMany(p => p.Produto).WithOne(i => i.Itens);
            builder.Property(i => i.ProdutoId).IsRequired();
            builder.Property(i => i.Quantidade).IsRequired();
        }
    }
}
