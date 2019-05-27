using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class AtividadesPreferidasViewModel
    {
        private IList<AlunoViewModel> aluno;

        public AtividadesPreferidasViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int AtividadesPreferidaId { get; set; }

        public string Descricao { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
