using IBVL.Sistema.Domain.Entities;

namespace IBVL.Sistema.Domain.Interfaces
{
    public interface ITelefoneRepository
    {
        Task AdicionarTelefone(Telefone telefone);
        Task RemoverTelefone(Telefone telefone);


    }
}
