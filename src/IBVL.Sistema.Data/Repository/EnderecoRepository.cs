using IBVL.Sistema.Data.Context;
using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;

namespace IBVL.Sistema.Data.Repository
{
    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ApplicationDbContext _context;

        public EnderecoRepository(ApplicationDbContext context)
        => _context = context;


        public async Task AdicionarEnderecoAsync(Endereco endereco)
        {
            await _context.Enderecos.AddAsync(endereco);
            await _context.SaveChangesAsync();
        }

        public async Task<Endereco> AtualizarEnderecoAsync(Endereco endereco)
        {
            _context.Enderecos.Update(endereco);
            await _context.SaveChangesAsync();
            return endereco;
        }
    }
}


