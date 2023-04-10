using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Core.ValueObjcts;
using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IMembroRepository
    {

        Task<Membro> ObterMembroPorIdAsync(Guid id);
        Task<Membro> ObterMembroPorCPFAsync(string cpf);
        Task<Membro> ObterMembroPorRGAsync(string rg);
        Task<Membro> ObterMembroEmailAsync(string email);
        Task<Membro> ObterMembroPorCargoPastoraisAsync(CargoPastoral cargoPastoral);
        Task<IEnumerable<Membro>> ObterMembrosPorProfissaoAsync(Profissao profissao);      
        Task<IEnumerable<Membro>> ObterMembrosPorSexoAsync(string sexo, int paginas, int limite);
        Task<IEnumerable<Membro>> ObterMembrosAsync(bool ativo, int paginas, int limite);
        Task<IEnumerable<Membro>> ObterMembrosPorCargoPastoraisAsync(CargoPastoral cargo, int pagina, int limite);
        Task<IEnumerable<Membro>> ObterMembrosPorSituacaoAsync(string situacao, int pagina, int limite);
        Task<Membro> AdicionarMembroAsync(Membro membro);
        Task<Membro> AtualizarMembroAsync(Membro membro);        
        Task RemoverMembroAsync(Guid id);

        Task CadastrarEnderecoAsync( Endereco endereco);
        Task AtualizarEnderecoAsync( Endereco endereco);

        Task  CadastrarTelefoneAsync(List<Telefone> telefones);
        Task RemoverTelefoneAsync(Membro membro, string numero);

        Task CadastrarMembroProfissaoAsync( List<MembroProfissao> membroProfissoes);
        Task  RemoverProfissaoAsync(Guid MembroId, Guid profissaoId);

        Task CadastrarCargoPastoralAsync(Guid membroId, CargoPastoral cargoPastoral);
        Task RemoverCargoPastoralAsync(Guid membroId, Guid cargoPastoralId);




    }
}
