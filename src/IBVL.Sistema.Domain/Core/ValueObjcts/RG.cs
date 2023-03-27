using IBVL.Sistema.Domain.Exceptions;

namespace IBVL.Sistema.Domain.Core.ValueObjcts
{
    public class RG
    {
        private const int _DIGITOS = 9;
        public string Numero;
        public string OrgaoEmissor { get; set; }
        public DateTime DataEmissao { get; set; }

        public RG(string numero)
        {
            DomainValidationException.Quando(!numero.Length.Equals(_DIGITOS), " RG com quantidades de dígitos inválido!");
          
        }

    }
}
