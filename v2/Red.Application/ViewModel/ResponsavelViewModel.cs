using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Application.ViewModel
{
    public partial class ResponsavelViewModel
    {
        private IList<AlunoViewModel> alunos;

        public ResponsavelViewModel()
        {
            alunos = new List<AlunoViewModel>();
        }

        public int ResponsavelId { get; set; }

        [StringLength(75)]
        public string Responsavel1 { get; set; }

        [StringLength(75)]
        public string Responsavel2 { get; set; }

        [StringLength(50)]
        public string Documento { get; set; }

        [StringLength(75)]
        public string Endereco { get; set; }

        [StringLength(30)]
        public string Bairro { get; set; }

        [StringLength(9)]
        public string Cep { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Uf { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        [StringLength(15)]
        public string Celular1 { get; set; }

        [StringLength(15)]
        public string Celular2 { get; set; }

        public virtual IList<AlunoViewModel> Alunos
        {
            get => alunos;
            set => alunos = value;
        }
    }
}
