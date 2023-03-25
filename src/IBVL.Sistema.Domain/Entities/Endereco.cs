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


        private void Validar()
        {
            DomainValidationException.Quando(Logradouro.Length > 100, "");
        }



       
    }

}
