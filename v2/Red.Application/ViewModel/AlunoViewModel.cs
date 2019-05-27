using System;
using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class AlunoViewModel
    {
        private IList<AtividadesPreferidasViewModel> atividadesPreferida;
        private IList<CaracteristicaViewModel> caracteristica;
        private IList<ProblemasDeSaudeViewModel> problemasSaude;
        private IList<TurmaViewModel> turma;

        public AlunoViewModel()
        {
            atividadesPreferida = new List<AtividadesPreferidasViewModel>();
            caracteristica = new List<CaracteristicaViewModel>();
            problemasSaude = new List<ProblemasDeSaudeViewModel>();
            turma = new List<TurmaViewModel>();
        }

        public int AlunoId { get; set; }

        public string Nome { get; set; }

        public int? ResponsavelId { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Sexo { get; set; }

        public bool GrupoDeJovens { get; set; }

        public bool Matriculado { get; set; }

        public int StatusId { get; set; }

        public string Observacao { get; set; }

        public virtual ResponsavelViewModel Responsavel { get; set; }

        public virtual StatusViewModel Status { get; set; }

        public virtual IList<AtividadesPreferidasViewModel> AtividadesPreferida
        {
            get => atividadesPreferida;
            set => atividadesPreferida = value;
        }

        public virtual IList<CaracteristicaViewModel> Caracteristica
        {
            get => caracteristica;
            set => caracteristica = value;
        }

        public virtual IList<ProblemasDeSaudeViewModel> ProblemasSaude
        {
            get => problemasSaude;
            set => problemasSaude = value;
        }

        public virtual IList<TurmaViewModel> Turma
        {
            get => turma;
            set => turma = value;
        }
    }
}
