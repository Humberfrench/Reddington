using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class AlunoTurma
    {
        public int TurmaId { get; set; }
        public int AlunoId { get; set; }

        [ForeignKey("AlunoId")]
        [InverseProperty("AlunoTurma")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("TurmaId")]
        [InverseProperty("AlunoTurma")]
        public virtual Turma Turma { get; set; }
    }
}