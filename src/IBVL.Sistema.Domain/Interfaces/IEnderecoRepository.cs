using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task AdicionarEnderecoAsync(Endereco endereco);
        Task<Endereco> AtualizarEnderecoAsync(Endereco endereco);

    }
}
