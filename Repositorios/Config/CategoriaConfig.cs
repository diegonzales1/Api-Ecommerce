using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio
{
    public class CategoriaConfig : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Modelo).IsRequired();
            builder.Property(c => c.Genero).IsRequired();
            builder.HasMany(c => c.Produtos).WithOne(p => p.Categoria);
        }
    }
}