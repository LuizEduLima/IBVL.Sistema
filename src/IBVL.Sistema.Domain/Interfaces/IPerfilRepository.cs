using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task AdicionarPerfilAdministradorUsuarioAsync(Usuario usuario);
        Task AdicionarPerfilGerenteUsuarioAsync(Usuario usuario);
        Task RemoverPerfilUsuarioAsync(Usuario usuario);
        Task AtualizarPerfilUsuarioAsync(Usuario usuario, string perfil);
    }
}
