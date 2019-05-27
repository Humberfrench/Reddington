using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class ResponsavelViewModel
    {
        private IList<AlunoViewModel> aluno;

        public ResponsavelViewModel()
        {
            aluno = new List<AlunoViewModel>();
        }

        public int ResponsavelId { get; set; }

        public string Responsavel1 { get; set; }

        public string Responsavel2 { get; set; }

        public string Documento { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cep { get; set; }

        public string Cidade { get; set; }

        public string Uf { get; set; }

        public string Telefone { get; set; }

        public string Celular1 { get; set; }

        public string Celular2 { get; set; }

        public virtual IList<AlunoViewModel> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
