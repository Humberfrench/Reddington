using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class TurmaViewModel
    {
        private IList<AlunoViewModel> aluno;

        public TurmaViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int TurmaId { get; set; }

        public string NomeSala { get; set; }

        public int EvangelizadorId { get; set; }

        public int Ano { get; set; }

        public virtual EvangelizadorViewModel Evangelizador { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
