using IBVL.Sistema.Data.Identity;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IBVL.Sistema.Data.Repository
{
    public class PerfilRepository : IPerfilRepository
    {
        private readonly RoleManager<IdentityRole> _perfilManager;
        private readonly UserManager<ApplicationUser> _usuarioManager;

        public PerfilRepository(RoleManager<IdentityRole> perfilManager,
            UserManager<ApplicationUser> usuarioManager)
        {
            _perfilManager = perfilManager;
            _usuarioManager = usuarioManager;
        }

        public async Task AdicionarPerfilAdministradorUsuario(Usuario usuario)
        {
            var usuarioResult = await _usuarioManager.FindByEmailAsync(usuario.Login);

            if (usuarioResult == null) return;

            await _usuarioManager.AddToRoleAsync(usuarioResult, "admin");


        }

        public async Task AdicionarPerfilGerenteUsuario(Usuario usuario)
        {
            var usuarioResult = await _usuarioManager.FindByEmailAsync(usuario.Login);

            if (usuarioResult == null) return;

            await _usuarioManager.AddToRoleAsync(usuarioResult, "gerente");

        }

        public async Task AtualizarPerfilUsuario(Usuario usuario, string perfil)
        {
            var usuarioResult = await _usuarioManager.FindByEmailAsync(usuario.Login);

            if (usuarioResult == null) return;
            var perfilAtual = await _usuarioManager.GetRolesAsync(usuarioResult);

            if(perfilAtual == null)return;

            await _usuarioManager.RemoveFromRoleAsync(usuarioResult, perfilAtual[0].ToString());

            await _usuarioManager.AddToRoleAsync(usuarioResult, perfil);
        }

        public async Task RemoverPerfilUsuario(Usuario usuario)
        {
            var usuarioResult = await _usuarioManager.FindByEmailAsync(usuario.Login);

            if (usuarioResult == null) return;

            var perfilAtual = await _usuarioManager.GetRolesAsync(usuarioResult);
            if (perfilAtual == null) return;

            await _usuarioManager.RemoveFromRoleAsync(usuarioResult, perfilAtual[0].ToString());


        }
    }
}


