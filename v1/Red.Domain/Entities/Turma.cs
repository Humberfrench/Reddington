using System.Collections.Generic;
using Red.Domain.Interfaces;

namespace Red.Domain.Entities
{
    public class Turma : IEntidade 
    {
        public Turma()
        {
            alunos = new List<Aluno>();
            evangelizador = new Evangelizador();
        }
        private IList<Aluno> alunos;
        private int codigo;
        private Evangelizador evangelizador; 
        private string nomeSala;
        private int ano;

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

        public virtual Evangelizador Evangelizador
        {
            get
            {
                return evangelizador;
            }
            set
            {
                evangelizador = value;
            }
        }

        public virtual string NomeSala
        {
            get
            {
                return nomeSala;
            }
            set
            {
                nomeSala = value;
            }
        }

        public virtual int Ano
        {
            get
            {
                return ano;
            }
            set
            {
                ano = value;
            }
        }

        public virtual IList<Aluno> Alunos
        {
            get
            {
                return alunos;
            }
            set
            {
                alunos = value;
            }
        }
    }
}
