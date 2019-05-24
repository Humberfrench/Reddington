using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("AlunoProblemaSaude")]
    public class AlunoProblemaSaude
    {

        [Key]
        [Column(Name = "AlunoId", TypeName = "int", Order = 1)]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        [Key]
        [Column(Name = "ProblemaSaudeId", TypeName = "int", Order = 2)]
        [Required]
        [Display(Name = "Problema Saude Id")]
        public int ProblemaSaudeId { get; set; }
    }
}
