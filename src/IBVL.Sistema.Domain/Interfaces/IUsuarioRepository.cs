using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Task AdicionarUsuario(Usuario usuario);
        Task RemoverUsuario(Guid id);
        Task<IEnumerable<Usuario>> ObterUsuarios();
    }
}
