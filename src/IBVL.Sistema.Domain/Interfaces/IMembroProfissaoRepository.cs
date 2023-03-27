using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IMembroProfissaoRepository
    {
        Task AdicionarMembroProfissao(Membro membro, Profissao profissao);
        Task RemoverPromissaoMembro(Membro membro, Profissao profissao);
    }
}
