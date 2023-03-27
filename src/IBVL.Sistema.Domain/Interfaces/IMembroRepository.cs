using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IMembroRepository
    {

        Task<Membro> ObterMembroPorId(Guid id);
        Task<IEnumerable<Membro>> ObterMembros(int paginas, int limite);
        Task<Membro> AdicionarMembro(Membro membro);
        Task<Membro> AtualizarMembro(Membro membro);        
        Task RemoverMembro(Guid id);

    }
}
