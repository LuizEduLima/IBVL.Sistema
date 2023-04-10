using AutoMapper;
using IBVL.Sistema.Application.Dtos;
using IBVL.Sistema.Application.Interfaces;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;

namespace IBVL.Sistema.Application.Services
{
    public class MembroServices : IMembroServices
    {
        private readonly IMembroRepository _membroRepository;
        private readonly IMapper _mapper;

        public MembroServices(IMembroRepository membroRepository, IMapper mapper)
        {
            _membroRepository = membroRepository;
            _mapper = mapper;
        }

        public async Task<MembroDto> AdicionarMembroAsync(MembroDto membro)
        {
            await _membroRepository.AdicionarMembroAsync(_mapper.Map<Membro>(membro));
            return membro;
        }

        public async Task AtualizarEnderecoAsync(EnderecoDto endereco)
        {
            await _membroRepository.AtualizarEnderecoAsync(_mapper.Map<Endereco>(endereco));
        }

        public async Task<MembroDto> AtualizarMembroAsync(MembroDto membro)
        {
            await _membroRepository.AtualizarMembroAsync(_mapper.Map<Membro>(membro));
            return membro;
        }

        public async Task CadastrarCargoPastoralAsync(Guid membroId, CargoPastoralDto cargoPastoral)
        {
            var membro = await ObterMembro(membroId);
            membro.CargoPastoral = _mapper.Map<CargoPastoral>(cargoPastoral);
            await _membroRepository.AtualizarMembroAsync(membro);

        }

        public async Task CadastrarEnderecoAsync(EnderecoDto endereco)
        {
            await _membroRepository.CadastrarEnderecoAsync(_mapper.Map<Endereco>(endereco));
        }

        public async Task CadastrarMembroProfissaoAsync(List<MembroProfissaoDto> membroProfissoes)
        {
            await _membroRepository.CadastrarMembroProfissaoAsync(_mapper.Map<List<MembroProfissao>>(membroProfissoes));
        }

        public async Task CadastrarTelefoneAsync(List<TelefoneDto> telefones)
        {
            await _membroRepository.CadastrarTelefoneAsync(_mapper.Map<List<Telefone>>(telefones));
        }

        public async Task<MembroDto> ObterMembroEmailAsync(string email)
        {
            return _mapper.Map<MembroDto>(await _membroRepository.ObterMembroEmailAsync(email));
        }

        public async Task<MembroDto> ObterMembroPorCargoPastoraisAsync(CargoPastoralDto cargoPastoral)
        {
            var membro = await _membroRepository.ObterMembroPorCargoPastoraisAsync(_mapper.Map<CargoPastoral>(cargoPastoral));

            return _mapper.Map<MembroDto>(membro);
        }

        public async Task<MembroDto> ObterMembroPorCPFAsync(string cpf)
        {
            var membro = await _membroRepository.ObterMembroPorCPFAsync(cpf);

            return _mapper.Map<MembroDto>(membro);
        }

        public async Task<MembroDto> ObterMembroPorIdAsync(Guid id)
        {
            var membro = await _membroRepository.ObterMembroPorIdAsync(id);

            return _mapper.Map<MembroDto>(membro);
        }

        public async Task<MembroDto> ObterMembroPorRGAsync(string rg)
        {
            return _mapper.Map<MembroDto>(await _membroRepository.ObterMembroPorRGAsync(rg));
        }

        public async Task<IEnumerable<MembroDto>> ObterMembrosAsync(bool ativo, int paginas, int limite)
        {
            return _mapper.Map<IEnumerable<MembroDto>>(await _membroRepository
                            .ObterMembrosAsync(ativo, paginas, limite));
        }

        public async Task<IEnumerable<MembroDto>> ObterMembrosPorCargoPastoraisAsync(CargoPastoralDto cargo, int pagina, int limite)
        {
            return _mapper.Map<IEnumerable<MembroDto>>(await _membroRepository
                          .ObterMembrosPorCargoPastoraisAsync(_mapper.Map<CargoPastoral>(cargo), pagina, limite));
        }

        public async Task<IEnumerable<MembroDto>> ObterMembrosPorProfissaoAsync(ProfissaoDto profissao)
        {
            return _mapper.Map<IEnumerable<MembroDto>>(await _membroRepository
                         .ObterMembrosPorProfissaoAsync(_mapper.Map<Profissao>(profissao)));
        }

        public async Task<IEnumerable<MembroDto>> ObterMembrosPorSexoAsync(string sexo, int paginas, int limite)
        {
            return _mapper.Map<IEnumerable<MembroDto>>(await _membroRepository
                         .ObterMembrosPorSexoAsync(sexo, paginas, limite));
        }

        public async Task<IEnumerable<MembroDto>> ObterMembrosPorSituacaoAsync(string situacao, int pagina, int limite)
        {
            return _mapper.Map<IEnumerable<MembroDto>>(await _membroRepository
                       .ObterMembrosPorSituacaoAsync(situacao, pagina, limite));
        }

        public async Task RemoverCargoPastoralAsync(Guid membroId, Guid cargoPastoralId)
        {
            await _membroRepository.RemoverCargoPastoralAsync(membroId, cargoPastoralId);
        }

        public async Task RemoverMembroAsync(Guid id)
        {
            await _membroRepository.RemoverMembroAsync(id);
        }

        public async Task RemoverProfissaoAsync(Guid MembroId, Guid profissaoId)
        {
            await _membroRepository.RemoverProfissaoAsync(MembroId, profissaoId);
        }

        public async Task RemoverTelefoneAsync(MembroDto membro, string numero)
        {
          await _membroRepository.RemoverTelefoneAsync(_mapper.Map<Membro>(membro),numero);
        }

        private async Task<Membro> ObterMembro(Guid id)
            => await _membroRepository.ObterMembroPorIdAsync(id);


    }
}
