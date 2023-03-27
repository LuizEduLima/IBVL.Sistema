using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBVL.Sistema.Data.EntitiesConfigurations
{
    public class CargoPastoralConfiguration : IEntityTypeConfiguration<CargoPastoral>
    {
        public void Configure(EntityTypeBuilder<CargoPastoral> builder)
        {
            builder.ToTable("CargosPastorais");

            builder.HasKey(k => k.Id);
            builder.Property(c => c.Nome)
                .HasMaxLength(50).IsRequired();
            builder.Property(c => c.Descricao)
               .HasMaxLength(250);

            builder.HasIndex(c => c.Nome).IsUnique();

            builder.HasData(
                new CargoPastoral("Membro", @"Pessoa que só participa do Rol de membros,
                                             não exercendo atividades ministeriais"));
        }
    }
}
