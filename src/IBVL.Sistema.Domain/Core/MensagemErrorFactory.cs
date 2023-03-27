namespace IBVL.Sistema.Domain.Core
{
    public static class MensagemErrorFactory
    {
        public static string MaximoCaractes(string campo, int valorMaximo)
            => $"O {campo} não deve ultrapassar o valor {valorMaximo} caracteres.";
        public static string MinimoMaximoCaractes(string campo, int valorMinimo, int valorMaximo)
          => $"O {campo} deve possuir entre {valorMinimo} e {MaximoCaractes} caracteres.";
        public static string EhObrigadorio(string campo)
         => $"O {campo} é de preenchimento obrigatório.";

    }
}
