using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task AdicionarTelefoneAsync(Telefone telefone);
        Task RemoverTelefoneAsync(Telefone telefone);


    }
}
