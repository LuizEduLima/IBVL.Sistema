using IBVL.Sistema.Domain.Core;
using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Core.ValueObjcts;

namespace IBVL.Sistema.Domain.Entities
{
    public class Membro : Entity
    {
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public EstadoCivil EstadoCivil { get; set; }
        public CPF CPF { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; } = "Brasileiro";
        public List<Telefone> Contatos { get; set; } = new();
        public List<Profissao> Profissoes { get; set; } = new();
        public List<CargoPastoral> Cargos { get; set; } = new();
        public bool EstaEmpregado { get; set; }
        public bool EhBatizado { get; set; }
        public bool EhDizimista { get; set; }
        public string Foto { get; set; }

    }

}
