using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("AlunoAtividadePreferida")]
    public class AlunoAtividadePreferida
    {

        [Key]
        [Column(Name = "AlunoId", TypeName = "int", Order = 1)]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        [Key]
        [Column(Name = "AtividadePreferidaId", TypeName = "int", Order = 2)]
        [Required]
        [Display(Name = "Atividade Preferida Id")]
        public int AtividadePreferidaId { get; set; }
    }
}
