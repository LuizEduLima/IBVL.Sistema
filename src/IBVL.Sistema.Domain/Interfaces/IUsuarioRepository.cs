using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuarioAsync(Usuario usuario);
        Task RemoverUsuarioAsync(Guid id);
        Task<IEnumerable<Usuario>> ObterUsuariosAsync();
    }
}
