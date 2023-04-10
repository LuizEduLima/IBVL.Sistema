using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace IBVL.Sistema.Data.Repository
{
    public class CargoPastoralRepository : ICargoPastoralRepository
    {
        private readonly ApplicationDbContext _context;

        public CargoPastoralRepository(ApplicationDbContext context)
        => _context = context;

        public async Task<CargoPastoral> AdicionarCargoPastoralAsync(CargoPastoral cargoPastoral)
        {
            await _context.CargoPastorais.AddAsync(cargoPastoral);
            await _context.SaveChangesAsync();
            return cargoPastoral;
        }

        public async Task<CargoPastoral> ObterCargoPastoralPorIdAsync(Guid id)
        => await _context.CargoPastorais.FirstOrDefaultAsync(c => c.Equals(id));

        public async Task<CargoPastoral> ObterCargoPastoralPorNomeAsync(string nome)
    => await _context.CargoPastorais.FirstOrDefaultAsync(c => c.Nome.Equals(nome));


        public async Task<IEnumerable<CargoPastoral>> ObterCargosPastoraisAsync(int paginas, int limite)
       => await _context.CargoPastorais
                        .Skip(paginas)
                        .Take(limite)
                        .ToListAsync();

        public async Task RemoverCargoPatoralAsync(Guid id)
        {
            var result = await ObterCargoPastoralPorIdAsync(id);
            if (result == null) return;

            _context.Remove(result);
           await _context.SaveChangesAsync();
        }
    }
}

