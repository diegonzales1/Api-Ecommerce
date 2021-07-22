using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ProdutoConfig : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Nome).IsRequired();
            builder.Property(p => p.Unidade).IsRequired();
            builder.Property(p => p.Marca).IsRequired();
            builder.Property(p => p.Cor).IsRequired();
            builder.Property(p => p.Descricao).IsRequired();
            builder.Property(p => p.Tamanho).IsRequired();
            builder.Property(p => p.Quantidade).IsRequired();
            builder.Property(p => p.Preco).IsRequired();
            builder.HasOne(c => c.Categoria).WithMany(p => p.Produtos);
        }
    }
}
