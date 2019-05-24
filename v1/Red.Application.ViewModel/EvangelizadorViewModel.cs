using System.Collections.Generic;
using System.Linq;

namespace Red.Application.ViewModel
{
    public class EvangelizadorViewModel
    {
        public EvangelizadorViewModel()
        {
            turmas = new List<TurmaViewModel>();
        }
        private IList<TurmaViewModel> turmas;
        private int codigo;
        private string nome;
        private string contato;
        private string email;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public virtual string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        public virtual string Contato
        {
            get
            {
                return contato;
            }
            set
            {
                contato = value;
            }
        }

        public virtual string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        public virtual IList<TurmaViewModel> Turmas
        {
            get
            {
                return turmas;
            }
            set
            {
                turmas = value;
            }
        }

        public bool PodeExcluir
        {
            get
            {
                return !Turmas.Any();
            }
        }

    }
}
