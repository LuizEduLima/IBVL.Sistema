using Microsoft.AspNetCore.Mvc;

namespace IBVL.Sistema.Application.Dtos
{
    public class UsuarioDto
    {
        public string Login { get; set; }
        public string Senha { get; set; }

        [HiddenInput]
        public Guid MembroId { get; set; }
    }
}
