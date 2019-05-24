using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.Application.ViewModel
{
    public class ResponsavelAlunoViewModel
    {
        public ResponsavelAlunoViewModel()
        {
            Alunos = new List<AlunoViewModel>();
        }

        public AlunoViewModel Aluno { get; set; }
        public ResponsavelViewModel Responsavel { get; set; }

        public IList<AlunoViewModel> Alunos { get; set; }

    }
}
