using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IBVL.Sistema.Data.EntitiesConfigurations
{
    public class MembroProfissaoConfiguration : IEntityTypeConfiguration<MembroProfissao>
    {
        public void Configure(EntityTypeBuilder<MembroProfissao> builder)
        {
            builder.ToTable("MembrosProfissoes");

            builder.HasIndex(p => new { p.ProfissaoId, p.MembroId }).IsUnique();



        }
    }



}
