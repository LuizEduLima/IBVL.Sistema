using IBVL.Sistema.Domain.Core;

namespace IBVL.Sistema.Domain.Entities
{
    public class MembroProfissao : Entity
    {
        public Guid MembroId { get; set; }
        public Membro Membro { get; set; }

        public Guid ProfissaoId { get; set; }
        public Profissao Profissao { get; set; }

    }
}
