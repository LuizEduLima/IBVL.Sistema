using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IMembroProfissaoRepository
    {
        Task AdicionarMembroProfissaoAsync(Membro membro, Profissao profissao);
        Task RemoverPromissaoMembroAsync(Membro membro, Profissao profissao);
    }
}
