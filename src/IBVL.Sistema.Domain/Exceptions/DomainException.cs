namespace IBVL.Sistema.Domain.Exceptions
{
    public class DomainValidationException : Exception
    {
        public DomainValidationException(string mensagemError) : base(mensagemError) { }

        public static void Quando(bool invalido, string mensagemError)
        {
            if (invalido) throw new DomainValidationException(mensagemError);
        }

    }
}
