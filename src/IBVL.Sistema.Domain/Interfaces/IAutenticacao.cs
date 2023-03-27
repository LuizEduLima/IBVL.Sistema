using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IAutenticacao
    {
        Task<bool> UsuarioEstaAutenticado(string email, string senha);
        Task<bool> RegistrarUsuario(string email, string senha);
        Task Logout();

    }
}
