using IBVL.Sistema.Application.Dtos;

namespace IBVL.Sistema.Application.Interfaces
{
    public interface IMembroServices
    {
        Task<MembroDto> ObterMembroPorIdAsync(Guid id);
        Task<MembroDto> ObterMembroPorCPFAsync(string cpf);
        Task<MembroDto> ObterMembroPorRGAsync(string rg);
        Task<MembroDto> ObterMembroEmailAsync(string email);
        Task<MembroDto> ObterMembroPorCargoPastoraisAsync(CargoPastoralDto cargoPastoral);
        Task<IEnumerable<MembroDto>> ObterMembrosPorProfissaoAsync(ProfissaoDto profissao);
        Task<IEnumerable<MembroDto>> ObterMembrosPorSexoAsync(string sexo, int paginas, int limite);
        Task<IEnumerable<MembroDto>> ObterMembrosAsync(bool ativo, int paginas, int limite);
        Task<IEnumerable<MembroDto>> ObterMembrosPorCargoPastoraisAsync(CargoPastoralDto cargo, int pagina, int limite);
        Task<IEnumerable<MembroDto>> ObterMembrosPorSituacaoAsync(string situacao, int pagina, int limite);
        Task<MembroDto> AdicionarMembroAsync(MembroDto membro);
        Task<MembroDto> AtualizarMembroAsync(MembroDto membro);
        Task RemoverMembroAsync(Guid id);

        Task CadastrarEnderecoAsync(EnderecoDto endereco);
        Task AtualizarEnderecoAsync(EnderecoDto endereco);

        Task CadastrarTelefoneAsync(List<TelefoneDto> telefones);
        Task RemoverTelefoneAsync(MembroDto membro, string numero);

        Task CadastrarMembroProfissaoAsync(List<MembroProfissaoDto> membroProfissoes);
        Task RemoverProfissaoAsync(Guid MembroId, Guid profissaoId);

        Task CadastrarCargoPastoralAsync(Guid membroId, CargoPastoralDto cargoPastoral);
        Task RemoverCargoPastoralAsync(Guid membroId, Guid cargoPastoralId);

    }
}
