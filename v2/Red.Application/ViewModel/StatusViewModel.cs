using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class StatusViewModel
    {
        private IList<AlunoViewModel> aluno;

        public StatusViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int StatusId { get; set; }

        public string Descricao { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
