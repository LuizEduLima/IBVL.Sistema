using IBVL.Sistema.Domain.Core.Enums;
using IBVL.Sistema.Domain.Core.ValueObjcts;
using IBVL.Sistema.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace IBVL.Sistema.Application.Dtos
{
    public class MembroDto
    {
        [Required]
        public string Nome { get; set; }
        public string Apelido { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Sexo { get; set; }
        public string Etnia { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; } = "Brasileiro";
        public string EstadoCivil { get; set; }

        public string GrupoSanquineo { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public bool EstaEmpregado { get; set; }
        public bool EhBatizado { get; set; }
        public bool EhDizimista { get; set; }
        public string Situacao { get; set; }
        public string FormaAdimissao { get; set; }
        public string GrauEstrucao { get; set; }
        public DateTime DataAdimissao { get; set; }
        public DateTime DataDesligamento { get; set; }
        public string Foto { get; set; }
        public string Observacao { get; set; }
        public Guid UsuarioId { get; set; }
        public string Email { get; set; }        
        public EnderecoDto Endereco { get; set; }
    }
}
