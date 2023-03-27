using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IPerfilRepository
    {
        Task AdicionarPerfilUsuario(Usuario usuario);
        Task RemoverPerfilUsuario(Usuario usuario);
        Task AtualizarPerfilUsuario(Usuario usuario);
    }
}
