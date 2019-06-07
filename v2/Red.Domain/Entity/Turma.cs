using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Turma")]
    public partial class Turma
    {
        private IList<Aluno> aluno;

        public int TurmaId { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeSala { get; set; }

        public int EvangelizadorId { get; set; }

        public int Ano { get; set; }

        public virtual Evangelizador Evangelizador { get; set; }

    }
}
