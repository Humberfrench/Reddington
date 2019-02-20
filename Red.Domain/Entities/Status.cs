using System.Collections.Generic;
using Red.Domain.Interfaces;

namespace Red.Domain.Entities
{
    public class Status : IEntidade 
    {
        public Status()
        {
            alunos = new List<Aluno>();
        }

        private IList<Aluno> alunos;
        private int codigo;
        private string descricao;

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

        public virtual string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
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

