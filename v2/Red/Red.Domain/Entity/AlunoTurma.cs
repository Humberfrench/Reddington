using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("AlunoTurma")]
    public class AlunoTurma
    {

        [Key]
        [Column(Name = "TurmaId", TypeName = "int", Order = 1)]
        [Required]
        [Display(Name = "Turma Id")]
        public int TurmaId { get; set; }
        [Key]
        [Column(Name = "AlunoId", TypeName = "int", Order = 2)]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
    }
}
