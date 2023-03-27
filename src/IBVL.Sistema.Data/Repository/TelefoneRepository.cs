using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

public class TelefoneRepository : ITelefoneRepository
{

    private readonly ApplicationDbContext _applicationDbContext;

    public TelefoneRepository(ApplicationDbContext applicationDbContext)
    => _applicationDbContext = applicationDbContext;


    public async Task AdicionarTelefone(Telefone telefone)
    {
        await _applicationDbContext.Telefones.AddAsync(telefone);
        await _applicationDbContext.SaveChangesAsync();
    }

    public async Task RemoverTelefone(Telefone telefone)
    {
        var result = await ObterTelefone(telefone.MembroId);
        if (result == null) return;

        _applicationDbContext.Telefones.Remove(result);
        await _applicationDbContext.SaveChangesAsync();
    }

    private async Task<Telefone> ObterTelefone(Guid id)
   => await _applicationDbContext.Telefones.FirstOrDefaultAsync(t => t.MembroId == id);
}


