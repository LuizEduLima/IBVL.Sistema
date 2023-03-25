using IBVL.Sistema.Domain.Core;
using IBVL.Sistema.Domain.Exceptions;

namespace IBVL.Sistema.Domain.Entities
{
    public class CargoPastoral : Entity
    {
        public CargoPastoral(string nome, string descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public string Nome { get; set; }
        public string Descricao { get; set; }

        private void Validar()
        {
            DomainValidationException.Quando(Nome.Length > 100, MensagemFactoryErros.MaximoCaractes("Nome", 100));
            DomainValidationException.Quando(Nome.Length < 2, MensagemFactoryErros.MinimoMaximoCaractes("Nome", 5, 100));
            DomainValidationException.Quando(string.IsNullOrEmpty(Nome), MensagemFactoryErros.EhObrigadorio("Nome"));

            DomainValidationException.Quando(Descricao.Length > 150, MensagemFactoryErros.MaximoCaractes("Descrição", 150));
            DomainValidationException.Quando(Descricao.Length < 2, MensagemFactoryErros.MinimoMaximoCaractes("Descrição", 5, 150));
            DomainValidationException.Quando(string.IsNullOrEmpty(Descricao), MensagemFactoryErros.EhObrigadorio("Descrição"));

        }
    }

}

}
