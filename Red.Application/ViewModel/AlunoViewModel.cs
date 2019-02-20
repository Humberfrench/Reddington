using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Application.ViewModel
{
    public class AlunoViewModel
    {
        public AlunoViewModel()
        {

            AtividadesPreferidas = new List<AtividadePreferidaViewModel>();
            ProblemaSaudes = new List<ProblemaSaudeViewModel>();
            Caracteristicas = new List<CaracteristicaViewModel>();

        }

        [Display(Name = "Código")]
        [DisplayFormat(NullDisplayText = "0")]
        public int Codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(100)]
        [DisplayFormat(NullDisplayText = "")]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Sexo é obrigatório.")]
        [MaxLength(1)]
        [DisplayFormat(NullDisplayText = "")]
        public string Sexo { get; set; }

        [Display(Name = "Data de Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatório.")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.DateTime, ErrorMessage = "Data inválida")]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Observacao")]
        [Required(ErrorMessage = "Observacao é obrigatório.")]
        [MaxLength(250)]
        [DisplayFormat(NullDisplayText = "")]
        public string Observacao { get; set; }

        [Display(Name = "Grupo de Jovens?")]
        [DisplayFormat(NullDisplayText = "")]
        public bool GrupoDeJovens { get; set; }

        [Display(Name = "Aluno Matriculado?")]
        [DisplayFormat(NullDisplayText = "")]
        public bool Matriculado { get; set; }

        [Display(Name = "Status")]
        [Required(ErrorMessage = "Status é obrigatório.")]
        [DisplayFormat(NullDisplayText = "")]
        public StatusViewModel Status { get; set; }

        [Display(Name = "Responsavel")]
        [Required(ErrorMessage = "Responsavel é obrigatório.")]
        [DisplayFormat(NullDisplayText = "")]
        public ResponsavelViewModel Responsavel { get; set; }

        [ScaffoldColumn(false)]
        public IList<AtividadePreferidaViewModel> AtividadesPreferidas { get; set; }

        [ScaffoldColumn(false)]
        public IList<ProblemaSaudeViewModel> ProblemaSaudes { get; set; }

        [ScaffoldColumn(false)]
        public IList<CaracteristicaViewModel> Caracteristicas { get; set; }
    }
}
