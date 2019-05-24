using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Caracteristica")]
    public partial class Caracteristica
    {
        private IList<Aluno> aluno;

        public Caracteristica()
        {
            aluno = new List<Aluno>();
        }

        public int CaracteristicaId { get; set; }

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
