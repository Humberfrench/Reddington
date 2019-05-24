using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class AlunoProblemaSaude
    {
        public int AlunoId { get; set; }
        public int ProblemaSaudeId { get; set; }

        [ForeignKey("AlunoId")]
        [InverseProperty("AlunoProblemaSaude")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("ProblemaSaudeId")]
        [InverseProperty("AlunoProblemaSaude")]
        public virtual ProblemasSaude ProblemaSaude { get; set; }
    }
}