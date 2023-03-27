using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;

namespace IBVL.Sistema.Data.Repository
{
    public class MembroRepository : IMembroRepository
    {
        public Task<Membro> AdicionarMembro(Membro membro)
        {
            throw new NotImplementedException();
        }

        public Task<Membro> AtualizarMembro(Membro membro)
        {
            throw new NotImplementedException();
        }

        public Task<Membro> ObterMembroPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Membro>> ObterMembros(int paginas, int limite)
        {
            throw new NotImplementedException();
        }

        public Task RemoverMembro(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
  

