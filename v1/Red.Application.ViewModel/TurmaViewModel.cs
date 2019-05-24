using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public class TurmaViewModel
    {
        public TurmaViewModel()
        {
            alunos = new List<AlunoViewModel>();
            evangelizador = new EvangelizadorViewModel();
        }
        private IList<AlunoViewModel> alunos;
        private int codigo;
        private EvangelizadorViewModel evangelizador; 
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

        public virtual EvangelizadorViewModel Evangelizador
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
