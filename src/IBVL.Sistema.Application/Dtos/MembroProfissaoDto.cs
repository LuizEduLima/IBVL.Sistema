using IBVL.Sistema.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBVL.Sistema.Application.Dtos
{
    public class MembroProfissaoDto
    {
        public Guid MembroId { get; set; }
        public Guid ProfissaoId { get; set; }


    }
}
