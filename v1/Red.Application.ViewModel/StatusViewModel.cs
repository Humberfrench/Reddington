using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Red.Application.ViewModel
{
    public class StatusViewModel
    {
        public StatusViewModel()
        {
            Alunos = new List<AlunoViewModel>();
        }

        public int Codigo { get; set; }
        public string Descricao { get; set; }
        
        [JsonIgnore]
        public virtual ICollection<AlunoViewModel> Alunos { get; set; }
    }
}
