using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IBVL.Sistema.Data.Identity
{
    public class UsuarioPadraoIdentity : IUsuarioInicialIdentity
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UsuarioPadraoIdentity(UserManager<ApplicationUser> userManager)
        =>  _userManager = userManager;

        public async Task AdicionarUsuarioPadrao()
        {
            if (_userManager.FindByEmailAsync("admin.ibvl@ibvl.com.br").Result == null)
            {
                var usuarioAdmin = new ApplicationUser
                {
                    Email = "admin.ibvl@ibvl.com.br",
                    NormalizedEmail = "admin.ibvl@ibvl.com.br".ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var usuarioResult = await _userManager.CreateAsync(usuarioAdmin, "@AdminIBVL");

                if (usuarioResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usuarioAdmin, "admin");
                }

            }
            if (_userManager.FindByEmailAsync("gerente.ibvl@ibvl.com.br").Result == null)
            {
                var usuarioGerente = new ApplicationUser
                {
                    Email = "gerente.ibvl@ibvl.com.br",
                    NormalizedEmail = "gerente.ibvl@ibvl.com.br".ToUpper(),
                    EmailConfirmed = true,
                    LockoutEnabled = false,
                    SecurityStamp = Guid.NewGuid().ToString(),
                };
                var usuarioResult = await _userManager.CreateAsync(usuarioGerente, "@GerenteIBVL");

                if (usuarioResult.Succeeded)
                {
                    await _userManager.AddToRoleAsync(usuarioGerente, "gerente");
                }

            }
        }
    }
}
