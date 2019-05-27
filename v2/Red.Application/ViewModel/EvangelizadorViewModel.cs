using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class EvangelizadorViewModel
    {
        private ICollection<TurmaViewModel> turma;

        public EvangelizadorViewModel()
        {
            turma = new HashSet<TurmaViewModel>();
        }

        public int EvangelizadorId { get; set; }

        public string Nome { get; set; }

        public string Contato { get; set; }

        public string Email { get; set; }

        public virtual ICollection<TurmaViewModel> Turma
        {
            get => turma;
            set => turma = value;
        }
    }
}
