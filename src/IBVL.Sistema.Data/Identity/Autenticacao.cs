using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IBVL.Sistema.Data.Identity
{
    public class Autenticacao : IAutenticacao
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public Autenticacao(UserManager<IdentityUser> userManager,
                            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegistrarUsuario(string email, string senha)
        {
            var usuario = new IdentityUser
            {
                UserName = email,
                NormalizedUserName = email.ToUpper(),
                Email = email,
                EmailConfirmed = true,
                NormalizedEmail = email.ToUpper()
            };

            var result = await _userManager.CreateAsync(usuario, senha);

            return result.Succeeded == true;

        }

        public async Task<bool> UsuarioEstaAutenticado(string email, string senha)
        {
            var usuario = new IdentityUser
            {
                Email = email,
                NormalizedUserName = email.ToUpper(),
                UserName = email,
                NormalizedEmail = email.ToUpper()

            };
            var result = await _signInManager.PasswordSignInAsync(usuario, senha, false, false);
            return result.Succeeded == true;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
