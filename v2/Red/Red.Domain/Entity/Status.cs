using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Domain.Entity
{
    public partial class Status
    {
        private IList<Aluno> aluno;

        public Status()
        {
            aluno = new List<Aluno>();
        }

        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public virtual IList<Aluno> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
