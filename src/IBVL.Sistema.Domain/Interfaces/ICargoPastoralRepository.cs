using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface ICargoPastoralRepository
    {
        Task<CargoPastoral> ObterCargoPastoralPorIdAsync(Guid id);
        Task<IEnumerable<CargoPastoral>> ObterCargosPastoraisAsync(int paginas, int limite);
        Task<CargoPastoral> AdicionarCargoPastoralAsync(CargoPastoral cargoPastoral);
        Task RemoverCargoPatoralAsync(Guid id);
        Task<CargoPastoral> ObterCargoPastoralPorNomeAsync(string nome);
    }
}
