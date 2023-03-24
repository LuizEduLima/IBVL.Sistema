using IBVL.Sistema.Domain.Core;

namespace IBVL.Sistema.Domain.Entities
{
    public class Usuario : Entity
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }

}
