using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IBVL.Sistema.Data.Repository
{
    public class MembroProfissaoRepository : IMembroProfissaoRepository
    {
        private readonly ApplicationDbContext _context;

        public MembroProfissaoRepository(ApplicationDbContext context)
        => _context = context;


        public async Task AdicionarMembroProfissao(Membro membro, Profissao profissao)
        {
            await _context.MembrosProfissoes.AddAsync(new MembroProfissao { Membro = membro, Profissao = profissao });
            await _context.SaveChangesAsync();
        }

        public async Task RemoverPromissaoMembro(Membro membro, Profissao profissao)
        {
            var result = await ObterMembroProfissao(membro, profissao);
            if (result == null) return;

            _context.MembrosProfissoes.Remove(result);
            await _context.SaveChangesAsync();  
        }

        private async Task<MembroProfissao>ObterMembroProfissao(Membro membro, Profissao profissao)
            => await _context.MembrosProfissoes.FirstOrDefaultAsync(mp=>mp.MembroId== membro.Id && mp.ProfissaoId ==profissao.Id);
    }
}
  

