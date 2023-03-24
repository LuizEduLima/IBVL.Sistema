using IBVL.Sistema.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace IBVL.Sistema.Domain.Core.ValueObjcts
{
    public class CPF
    {
        private const int _DIGITOS = 11;
        public string Numero;

        public CPF(string numero)
        {
            DomainValidationException.Quando(!numero.Length.Equals(_DIGITOS), " CPF com quantidades de dígitos inválido!");
            DomainValidationException.Quando(!CpfValido(), "CPF inválido");
        }

        private bool CpfValido()
        {
            var reg = new Regex(@"([0-9]{2}[\.]?[0-9]{3}[\.]?[0-9]{3}[\/]?[0-9]{4}[-]?[0-9]{2})|([0-9]{3}[\.]?[0-9]{3}[\.]?[0-9]{3}[-]?[0-9]{2})", RegexOptions.IgnoreCase);
            return reg.IsMatch(Numero);
        }

    }
}
