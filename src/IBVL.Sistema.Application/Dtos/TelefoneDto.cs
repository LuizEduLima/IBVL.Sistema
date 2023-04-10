namespace IBVL.Sistema.Application.Dtos
{
    public class TelefoneDto
    {
        public Guid Id { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public Guid MembroId { get; set; }
    }
}
