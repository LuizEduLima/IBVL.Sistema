using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBVL.Sistema.Data.EntitiesConfigurations
{
    public class ProfissaoConfiguration : IEntityTypeConfiguration<Profissao>
    {
        public void Configure(EntityTypeBuilder<Profissao> builder)
        {
            builder.ToTable("Profissoes");

            builder.HasIndex(p => p.Nome).IsUnique();

            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
        }
    }



}
