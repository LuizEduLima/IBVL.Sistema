﻿using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace IBVL.Sistema.Data.Identity
{
    public class Autenticacao : IAutenticacao
    {

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public Autenticacao(UserManager<ApplicationUser> userManager,
                            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<bool> RegistrarUsuarioAsync(string email, string senha)
        {
            var usuario = new ApplicationUser
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = email,
                NormalizedUserName = email.ToUpper()
            };
            var usuarioResult = await _userManager.CreateAsync(usuario, senha);

            if (usuarioResult.Succeeded)
            {
                await _signInManager.SignInAsync(usuario, false);
                return true;
            }

            return false;



        }

        public async Task<bool> UsuarioEstaAutenticadoAsync(string email, string senha)
        {
            var usuario = new ApplicationUser
            {
                Email = email,
                NormalizedEmail = email.ToUpper(),
                UserName = email,
                NormalizedUserName = email.ToUpper()
            };

            var result = await _signInManager.PasswordSignInAsync(usuario, senha, false, false);
            return result.Succeeded;
        }
        public async Task LogoutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<bool> RemoverUsuarioAsync(string email)
        {
            var usuario = await _userManager.FindByEmailAsync(email);

            var result = await _userManager.RemoveLoginAsync(usuario, usuario.Email, usuario.SecurityStamp);

            return result.Succeeded;
        }
    }
}

