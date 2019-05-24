using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Red.Application.ViewModel
{
    public class CaracteristicaViewModel
    {
        public CaracteristicaViewModel()
        {
            alunos = new List<AlunoViewModel>();
        }

        private IList<AlunoViewModel> alunos;
        private int codigo;
        private string descricao;

        public virtual int Codigo
        {
            get
            {
                return codigo;
            }
            set
            {
                codigo = value;
            }
        }

        public virtual string Descricao
        {
            get
            {
                return descricao;
            }
            set
            {
                descricao = value;
            }
        }

        public virtual IList<AlunoViewModel> Alunos
        {
            get
            {
                return alunos;
            }
            set
            {
                alunos = value;
            }
        }

    }
}
