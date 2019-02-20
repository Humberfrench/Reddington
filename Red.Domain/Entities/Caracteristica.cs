using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Interfaces;

namespace Red.Domain.Entities
{
    public class Caracteristica : IEntidade 
    {
        public Caracteristica()
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
