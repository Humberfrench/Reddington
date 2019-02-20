using System.Collections.Generic;
using Red.Domain.Interfaces;

namespace Red.Domain.Entities
{
    public class Evangelizador : IEntidade 
    {
        public Evangelizador()
        {
            turmas = new List<Turma>();
        }
        private IList<Turma> turmas;
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

        public virtual IList<Turma> Turmas
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


    }
}
