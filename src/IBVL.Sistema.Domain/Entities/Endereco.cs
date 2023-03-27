



using IBVL.Sistema.Domain.Core;
using IBVL.Sistema.Domain.Exceptions;

namespace IBVL.Sistema.Domain.Entities
{
    public class Endereco : Entity
    {
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Estado { get; set; }
        public string CEP { get; set; }

        public Guid MembroId { get; set; }
        public Membro Membro { get; set; }

        private void Validar()
        {
            DomainValidationException.Quando(Logradouro.Length > 250, MensagemErrorFactory.MaximoCaractes("Locagrouro",250));
            DomainValidationException.Quando(string.IsNullOrEmpty(Logradouro), MensagemErrorFactory.EhObrigadorio("Logradouro"));
   
            DomainValidationException.Quando(string.IsNullOrEmpty(Numero), MensagemErrorFactory.EhObrigadorio("Numero"));

        }



       
    }

}
