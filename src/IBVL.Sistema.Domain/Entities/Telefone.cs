using IBVL.Sistema.Domain.Core;
using IBVL.Sistema.Domain.Core.Enums;

namespace IBVL.Sistema.Domain.Entities
{
    public class Telefone : Entity
    {
        public string Numero { get; set; }
        public TipoContato Tipo { get; set; }

        public Guid MembroId { get; set; }
        public Membro Membro { get; set; }

    }

}
