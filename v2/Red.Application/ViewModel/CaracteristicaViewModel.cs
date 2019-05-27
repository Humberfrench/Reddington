using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class CaracteristicaViewModel
    {
        private IList<AlunoViewModel> aluno;

        public CaracteristicaViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int CaracteristicaId { get; set; }

        public string Descricao { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
