using IBVL.Sistema.Domain.Core;
using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Core.ValueObjcts;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace IBVL.Sistema.Domain.Entities
{
    public class Membro : Entity
    {
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public Sexo Sexo { get; set; }
        public Etnia Etnia { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; } = "Brasileiro";
        public EstadoCivil EstadoCivil { get; set; }

        public GrupoSanquineo GrupoSanquineo { get; set; }
        public CPF CPF { get; set; }
        public RG RG { get; set; }
        public bool EstaEmpregado { get; set; }
        public bool EhBatizado { get; set; }
        public bool EhDizimista { get; set; }
        public Situacao Situacao { get; set; }
        public FormaAdimissao FormaAdimissao { get; set; }
        public GrauEstrucao GrauEstrucao { get; set; }
        public DateTime DataAdimissao { get; set; }
        public DateTime DataDesligamento { get; set; }
        public string Foto { get; set; }
        public string Observacao { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario Usuario { get; set; }



        public Guid EnderecoId { get; set; }
        [IgnoreDataMember] 
        public Endereco Endereco { get; set; }
        public List<Telefone> Contatos { get; set; } = new();
        public List<Profissao> Profissoes { get; set; } = new();
        public CargoPastoral CargoPastoral { get; set; } = new();



    }

}
