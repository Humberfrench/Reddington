using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public class ProblemasDeSaudeViewModel
    {
        private IList<AlunoViewModel> aluno;

        public ProblemasDeSaudeViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int ProblemaDeSaudeId { get; set; }

        public string Descricao { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
