namespace IBVL.Sistema.Domain.Core
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataAtualizacao { get; set; }
        public bool Ativo { get; set; } = true;

        protected Entity()
        {
            Id = Id == default ? Guid.NewGuid() : Id;
            DataCriacao = DataCriacao == default ? DateTime.Now : DataCriacao;
            DataCriacao = DataAtualizacao == default ? DateTime.Now : DataAtualizacao;
        }
    }
}
