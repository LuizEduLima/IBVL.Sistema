using IBVL.Sistema.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBVL.Sistema.Data.Identity
{
    internal class PerfilInicialIdentity : IPerfilInicialIdentity
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public PerfilInicialIdentity(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task AdicionarPerfilPadrao()
        {
            if (_roleManager.FindByIdAsync("admin").Result == null)
            {
                var papel = new IdentityRole
                {
                    Name = "admin",
                    NormalizedName = "admin".ToUpper()
                };
                await _roleManager.CreateAsync(papel);
            }

            if (_roleManager.FindByIdAsync("gerente").Result == null)
            {
                var papel = new IdentityRole
                {
                    Name = "gerente",
                    NormalizedName = "gerente".ToUpper()
                };
                await _roleManager.CreateAsync(papel);
            }

        }
    }
