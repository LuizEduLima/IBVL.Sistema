using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Core.ValueObjcts;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IBVL.Sistema.Data.Repository
{
    public class MembroRepository : IMembroRepository
    {
        private readonly ApplicationDbContext _context;

        public MembroRepository(ApplicationDbContext context)
        => _context = context;

        public async Task<Membro> AdicionarMembroAsync(Membro membro)
        {
            await _context.Membros.AddAsync(membro);
            await SaveChangeAsync();
            return membro;
        }

        public async Task AtualizarEnderecoAsync(Endereco endereco)
        {
            var end = await _context.Enderecos.FirstOrDefaultAsync(e => e.MembroId == endereco.MembroId);
            if (end == null) return;

            end = endereco;
            _context.Enderecos.Update(end);
            await SaveChangeAsync();
        }

        public async Task<Membro> AtualizarMembroAsync(Membro membro)
        {
            _context.Membros.Update(membro);
            await SaveChangeAsync();
            return membro;
        }

        public async Task CadastrarCargoPastoralAsync(Guid membroId, CargoPastoral cargoPastoral)
        {
            var membro = await ObterMembroAsync(membroId);
            if (membro == null) return;

            membro.CargoPastoral = cargoPastoral;

            _context.Membros.Update(membro);
            await SaveChangeAsync();
        }

        public async Task CadastrarEnderecoAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await SaveChangeAsync();
        }

        public async Task CadastrarMembroProfissaoAsync(List<MembroProfissao> membroProfissoes)
        {
            await _context.MembrosProfissoes.AddRangeAsync(membroProfissoes);
            await SaveChangeAsync();
        }

        public async Task CadastrarTelefoneAsync(List<Telefone> telefones)
        {
            await _context.Telefones.AddRangeAsync(telefones);
            await SaveChangeAsync();
        }

        public async Task<Membro> ObterMembroEmailAsync(string email)
        =>
            await _context.Membros.AsNoTracking()
                .Include(m => m.Endereco)
                .Include(m => m.Contatos)
                .Include(m => m.CargoPastoral)
                .Include(m => m.profissoes)
                .Include(m => m.Usuario)
                .Where(m => m.Usuario.Login == email)
                .FirstOrDefaultAsync();


        public async Task<Membro> ObterMembroPorCargoPastoraisAsync(CargoPastoral cargoPastoral)
        =>
            await _context.Membros.AsNoTracking()
                .Include(m => m.Endereco)
                .Include(m => m.Contatos)
                .Include(m => m.CargoPastoral)
                .Include(m => m.profissoes)
                .Include(m => m.Usuario)
                .Where(m => m.CargoPastoral == cargoPastoral)
                .FirstOrDefaultAsync();

        public async Task<Membro> ObterMembroPorCPFAsync(string cpf)
         =>
            await _context.Membros.AsNoTracking()
                .Include(m => m.Endereco)
                .Include(m => m.Contatos)
                .Include(m => m.CargoPastoral)
                .Include(m => m.profissoes)
                .Include(m => m.Usuario)
                .Where(m => m.CPF.Numero == cpf)
                .FirstOrDefaultAsync();

        public async Task<Membro> ObterMembroPorIdAsync(Guid id)
           => await _context.Membros.AsNoTracking()
                .Include(m => m.Endereco)
                .Include(m => m.Contatos)
                .Include(m => m.CargoPastoral)
                .Include(m => m.profissoes)
                .Include(m => m.Usuario)
                .Where(m => m.Id == id)
                .FirstOrDefaultAsync();

        public async Task<Membro> ObterMembroPorRGAsync(string rg)
          =>

            await _context.Membros.AsNoTracking()
                 .Include(m => m.Endereco)
                 .Include(m => m.Contatos)
                 .Include(m => m.CargoPastoral)
                 .Include(m => m.profissoes)
                 .Include(m => m.Usuario)
                 .Where(m => m.RG.Numero == rg)
                 .FirstOrDefaultAsync();


        public async Task<IEnumerable<Membro>> ObterMembrosAsync(bool ativo, int pagina, int limite)
       => await _context.Membros.Take(pagina)
            .Take(limite)
            .Where(m => m.Ativo == ativo)
            .ToListAsync();

        public async Task<IEnumerable<Membro>> ObterMembrosPorCargoPastoraisAsync(CargoPastoral cargo, int paginas, int limite)
         => await _context.Membros.Take(paginas)
            .Take(limite)
            .Where(m => m.CargoPastoral == cargo)
            .ToListAsync();

        public async Task<IEnumerable<Membro>> ObterMembrosPorProfissaoAsync(Profissao profissao)
       => await _context.MembrosProfissoes
                         .Where(m => m.Profissao == profissao)
                         .Select(m => m.Membro)
                         .ToListAsync();

        public async Task<IEnumerable<Membro>> ObterMembrosPorSexoAsync(string sexo, int paginas, int limite)
          => await _context.Membros.Take(paginas)
            .Take(limite)
            .Where(m => m.Sexo == Enum.Parse<Sexo>(sexo))
            .ToListAsync();

        public async Task<IEnumerable<Membro>> ObterMembrosPorSituacaoAsync(string situacao, int pagina, int limite)
         => await _context.Membros.Take(pagina)
            .Take(limite)
            .Where(m => m.Situacao == Enum.Parse<Situacao>(situacao))
            .ToListAsync();

        public async Task RemoverCargoPastoralAsync(Guid membroId, Guid cargoPastoralId)
        {
            var membro = await ObterMembroAsync(membroId);
            if (membro == null) return;

            var cargoPastoral = await _context.CargoPastorais.FirstOrDefaultAsync(c => c.Id == cargoPastoralId);
            membro.CargoPastoral = cargoPastoral;

            _context.Membros.Update(membro);
            await SaveChangeAsync();

        }

        public async Task RemoverMembroAsync(Guid id)
        {
            var memmbro = await ObterMembroAsync(id);
            if (memmbro == null) return;

            memmbro.Ativo = false;
            _context.Membros.Update(memmbro);

            await SaveChangeAsync();
        }

        public async Task RemoverProfissaoAsync(Guid MembroId, Guid profissaoId)
        {
            var mp = await _context.MembrosProfissoes.FirstOrDefaultAsync(mp => mp.MembroId == MembroId && mp.ProfissaoId == profissaoId);
            if (mp == null) return;

            _context.MembrosProfissoes.Remove(mp);
            await SaveChangeAsync();

        }

        public async Task RemoverTelefoneAsync(Membro membro, string numero)
        {
            var telefone = await _context.
                 Telefones.FirstOrDefaultAsync(t => t.Numero == numero && t.MembroId == membro.Id);

            if (telefone == null) return;

            _context.Telefones.Remove(telefone);
            await SaveChangeAsync();

        }

        public async Task SaveChangeAsync()
        {
            await _context.SaveChangesAsync();
            _context?.Dispose();
        }


        private async Task<Membro> ObterMembroAsync(Guid id)
            => await _context.Membros.FirstOrDefaultAsync(m => m.Id.Equals(id));

        private async Task<Membro> ObterMembroTelefonesAsync(Guid id)
           => await _context.Membros.AsNoTracking()
            .Include(m => m.Contatos)
            .FirstOrDefaultAsync(m => m.Id.Equals(id));





    }
}


