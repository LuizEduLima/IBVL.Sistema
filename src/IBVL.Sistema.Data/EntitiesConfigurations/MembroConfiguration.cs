using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IBVL.Sistema.Data.EntitiesConfigurations
{
    public class MembroConfiguration : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.ToTable("Membros");

            builder.HasKey(m => m.Id);

            builder.OwnsOne(m => m.RG, rg =>
            {
                rg.Property(r => r.Numero).HasColumnName("RG").HasMaxLength(9).IsRequired();
            });
            builder.OwnsOne(m => m.RG, rg =>
            {
                rg.Property(r => r.OrgaoEmissor).HasColumnName("OrgaoEmissor").HasMaxLength(40).IsRequired();
            });
            builder.OwnsOne(m => m.RG, rg =>
            {
                rg.Property(r => r.DataEmissao).HasColumnName("DataEmissao").IsRequired();
            });
            builder.OwnsOne(m => m.RG, rg =>
            {
                rg.HasIndex(r => r.Numero).IsUnique();
            });

            builder.OwnsOne(m => m.CPF, cpf =>
            {
                cpf.Property(c => c.Numero).HasColumnName("CPF").IsRequired().HasMaxLength(11);
            });
            builder.OwnsOne(m => m.CPF, cpf =>
            {
                cpf.HasIndex(c => c.Numero).IsUnique();
            });

            builder.Property(m => m.Nome).HasMaxLength(50).IsRequired();
            builder.Property(m => m.Apelido).HasMaxLength(30);
            builder.Property(m => m.Observacao).HasMaxLength(400);
            builder.Property(m => m.DataAdimissao).IsRequired();
            builder.Property(m => m.DataNascimento).IsRequired();
            builder.Property(m => m.Sexo).IsRequired();
            builder.Property(m => m.Situacao).IsRequired();
            builder.Property(m => m.Etnia).IsRequired();

            builder.Property(m => m.Situacao)
                  .HasConversion(new EnumToStringConverter<Situacao>()).HasMaxLength(30)
                  .IsRequired();

            builder.Property(m => m.Sexo)
               .HasConversion(new EnumToStringConverter<Sexo>()).HasMaxLength(10)
               .IsRequired();

            builder.Property(m => m.Etnia)
               .HasConversion(new EnumToStringConverter<Etnia>()).HasMaxLength(10)
               .IsRequired();

            builder.Property(m => m.GrauEstrucao)
               .HasConversion(new EnumToStringConverter<GrauEstrucao>()).HasMaxLength(30)
               .IsRequired();

            builder.Property(m => m.EstadoCivil)
               .HasConversion(new EnumToStringConverter<EstadoCivil>()).HasMaxLength(10)
               .IsRequired();

            builder.Property(m => m.GrupoSanquineo)
              .HasConversion(new EnumToStringConverter<GrupoSanquineo>()).HasMaxLength(15)
              .IsRequired();

            builder.Property(m => m.FormaAdimissao)
              .HasConversion(new EnumToStringConverter<FormaAdimissao>()).HasMaxLength(30)
              .IsRequired();

            builder.HasOne(m => m.Usuario)
                              .WithOne(u => u.Membro)
                              .HasForeignKey<Membro>(m => m.UsuarioId);


            builder.HasOne(m => m.Endereco)
                   .WithOne(u => u.Membro)
                   .HasForeignKey<Endereco>(e => e.MembroId);
                    

            builder.HasMany(m => m.Contatos)
                    .WithOne(t =>t.Membro);    






        }
    }



}
