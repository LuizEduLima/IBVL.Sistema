using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
public partial class TelefoneConfiguration
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios");

            builder.HasIndex(p => p.Login).IsUnique();

            builder.Property(p => p.Login).HasMaxLength(100).IsRequired();

            
        }
    }
}