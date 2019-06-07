using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Domain.Entity
{
    public partial class Status
    {
        private IList<Aluno> alunos;

        public Status()
        {
            alunos = new List<Aluno>();
        }

        [Key]
        public int StatusId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public virtual IList<Aluno> Alunos
        {
            get => alunos;
            set => alunos = value;
        }
    }
}
