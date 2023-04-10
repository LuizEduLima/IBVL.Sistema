using System.ComponentModel.DataAnnotations;

namespace IBVL.Sistema.Domain.Core.Enums
{
    public enum EstadoCivil
    {
        [Display(Name = "Casado(a)")]
        Casado,
        [Display(Name = "Solteiro(a)")]
        Solteiro,
        [Display(Name = "Viuvo(a)")]
        Viuvo,
        [Display(Name = "Divorciado(a)")]
        Divorciado,
        [Display(Name = "Separado(a)")]
        Separado
    }
}
