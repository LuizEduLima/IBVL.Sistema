using IBVL.Sistema.Domain.Entities;
using IBVL.Sistema.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBVL.Sistema.Data.Repository
{
    public class CargoPastoralRepository : ICargoPastoralRepository
    {
        public Task<CargoPastoral> AdicionarCargoPastoral(Membro membro)
        {
            throw new NotImplementedException();
        }

        public Task<CargoPastoral> ObterCargoPastoralPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CargoPastoral>> ObterCargosPastorais(int paginas, int limite)
        {
            throw new NotImplementedException();
        }

        public Task RemoverMembro(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
  

