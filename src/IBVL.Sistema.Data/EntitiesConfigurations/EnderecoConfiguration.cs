using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBVL.Sistema.Data.EntitiesConfigurations
{
    public class EnderecoConfiguration : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.ToTable("Enderecos");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Logradouro).IsRequired()
                .HasMaxLength(50);

            builder.Property(e => e.Numero).IsRequired().HasMaxLength(20);
            builder.Property(e => e.Bairro).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Cidade).IsRequired().HasMaxLength(50);
            builder.Property(e => e.Estado).IsRequired().HasMaxLength(2);
            builder.Property(e => e.CEP).IsRequired().HasMaxLength(8);
            builder.Property(e => e.Complemento).IsRequired().HasMaxLength(100);

         
        }
    }



}
