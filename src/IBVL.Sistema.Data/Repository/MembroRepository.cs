using IBVL.Sistema.Data.Context;
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


        public async Task<Membro> AdicionarMembro(Membro membro)
        {
            await _context.Membros.AddAsync(membro);
            await _context.SaveChangesAsync();
            return membro;
        }

        public async Task<Membro> AtualizarMembro(Membro membro)
        {
            _context.Membros.Update(membro);
            await _context.SaveChangesAsync();

            return membro;
        }

        public async Task<Membro> ObterMembroPorId(Guid id)
       => await _context.Membros
                        .AsNoTracking()
                        .Include(e=>e.Endereco)
                        .Include(t=>t.Contatos)
                        .Include(p=>p.Profissoes)
                        .Include(c=>c.CargoPastoral)
                        .Include(u=>u.Usuario)
                        .FirstOrDefaultAsync(m=>m.Id.Equals(id));


        public async Task<IEnumerable<Membro>> ObterMembros(int paginas, int limite)
          => await _context.Membros
                    .Skip(paginas)
                    .Take(limite)
                    .ToListAsync();

        public async Task RemoverMembro(Guid id)
        {
            var membroResult = await ObterMembroPorId(id);
            if (membroResult != null) return;

            membroResult.Ativo = false;

            await AtualizarMembro(membroResult);
        }
    }
}


