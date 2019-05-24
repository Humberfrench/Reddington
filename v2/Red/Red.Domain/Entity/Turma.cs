using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class Turma
    {
        public Turma()
        {
            AlunoTurma = new HashSet<AlunoTurma>();
        }

        public int TurmaId { get; set; }
        [Required]
        [StringLength(50)]
        public string NomeSala { get; set; }
        public int EvangelizadorId { get; set; }
        public int Ano { get; set; }

        [ForeignKey("EvangelizadorId")]
        [InverseProperty("Turma")]
        public virtual Evangelizador Evangelizador { get; set; }
        [InverseProperty("Turma")]
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
    }
}