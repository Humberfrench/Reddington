using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public class ProblemaSaudeViewModel
    {
        public ProblemaSaudeViewModel()
        {
            alunos = new List<AlunoViewModel>();
        }

        private IList<AlunoViewModel> alunos;
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

        public virtual IList<AlunoViewModel> Alunos
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
