using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Data.Identity;
using IBVL.Sistema.Data.Repository;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IBVL.Sistema.Ioc.DependencyInjectionConfig
{
    public static class DependencyDbContextConfiguration
    {
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configure)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configure.GetConnectionString("DefaultConnection"),
                    migration => migration.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });
            services.AddScoped<ApplicationDbContext>();
            services.AddDependencyInjection();
            services.AddIdentityDependencyInjection();

            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/";
            });

            return services;
        }
        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            services.AddScoped<IAutenticacao, Autenticacao>();
            services.AddScoped<ICargoPastoralRepository, CargoPastoralRepository>();
            services.AddScoped<IEnderecoRepository, EnderecoRepository>();
            services.AddScoped<IMembroProfissaoRepository, MembroProfissaoRepository>();
            services.AddScoped<IMembroRepository, MembroRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<ITelefoneRepository, TelefoneRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            return services;
        }
        private static IServiceCollection AddIdentityDependencyInjection(this IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            return services;
        }

    }

}

