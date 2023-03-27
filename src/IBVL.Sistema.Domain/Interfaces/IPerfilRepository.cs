using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task AdicionarPerfilAdministradorUsuario(Usuario usuario);
        Task AdicionarPerfilGerenteUsuario(Usuario usuario);
        Task RemoverPerfilUsuario(Usuario usuario);
        Task AtualizarPerfilUsuario(Usuario usuario, string perfil);
    }
}
