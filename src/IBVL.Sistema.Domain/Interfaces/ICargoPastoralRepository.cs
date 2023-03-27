using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface ICargoPastoralRepository
    {
        Task<CargoPastoral> ObterCargoPastoralPorId(Guid id);
        Task<IEnumerable<CargoPastoral>> ObterCargosPastorais(int paginas, int limite);
        Task<CargoPastoral> AdicionarCargoPastoral(Membro membro);
        Task RemoverMembro(Guid id);
    }
}
