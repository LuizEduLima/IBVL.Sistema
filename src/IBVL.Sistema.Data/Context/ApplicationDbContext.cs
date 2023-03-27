using IBVL.Sistema.Data.Identity;
using IBVL.Sistema.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IBVL.Sistema.Data.Context
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Membro> Membros { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Telefone> Telefones { get; set; }
        public DbSet<CargoPastoral> CargoPastorais { get; set; }
        public DbSet<Profissao> Profissoes { get; set; }
        public DbSet<MembroProfissao> MembrosProfissoes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options){ }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
