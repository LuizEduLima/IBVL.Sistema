using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Data.Identity;
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
            services.AddDbContext<ApplicationDbContext>(options => {
                options.UseSqlServer(configure.GetConnectionString("DefaultConnection"),
                    migration => migration.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            });

            services.AddIdentityDependencyInjection();

            return services;
        }
        private static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
          
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
