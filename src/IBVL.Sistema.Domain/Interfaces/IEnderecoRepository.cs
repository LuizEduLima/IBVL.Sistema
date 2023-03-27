using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface IEnderecoRepository
    {
        Task AdicionarEndereco(Endereco endereco);
        Task<Endereco> AtualizarEndereco(Endereco endereco);

    }
}
