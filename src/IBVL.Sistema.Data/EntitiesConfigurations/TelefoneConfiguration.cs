using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

public partial class TelefoneConfiguration : IEntityTypeConfiguration<Telefone>
{
    public void Configure(EntityTypeBuilder<Telefone> builder)
    {
        builder.ToTable("Telefones");

        builder.HasIndex(p => p.Id).IsUnique();

        builder.Property(p => p.Numero).HasMaxLength(12).IsRequired();

        builder.Property(p=>p.Tipo)
            .HasConversion(new EnumToStringConverter<TipoContato>()).HasMaxLength(15);

            
            
    }
}