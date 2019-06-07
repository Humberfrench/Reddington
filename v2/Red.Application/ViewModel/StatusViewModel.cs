using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class StatusViewModel
    {
        private IList<AlunoViewModel> alunos;

        public StatusViewModel()
        {
            alunos = new List<AlunoViewModel>();
        }

        public int StatusId { get; set; }

        public string Descricao { get; set; }

        public virtual IList<AlunoViewModel> Alunos
        {
            get => alunos;
            set => alunos = value;
        }
    }
}
