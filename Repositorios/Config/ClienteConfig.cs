using Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositorio.Config
{
    public class ClienteConfig : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Nome).IsRequired();
            builder.Property(c => c.Telefone).IsRequired();
            builder.Property(c => c.Email).IsRequired();
            builder.Property(c => c.CPFCNPJ).IsRequired();
            builder.Property(c => c.Endereco).IsRequired();
            builder.Property(c => c.DataDeNascimento).IsRequired();
            builder.Property(c => c.Sexo).IsRequired();

            builder.HasMany(c => c.Carrinhos).WithOne(c => c.Cliente);
        }

    }
}