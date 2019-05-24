using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("AlunoCaracteristica")]
    public class AlunoCaracteristica
    {

        [Key]
        [Column(Name = "AlunoId", TypeName = "int", Order = 1)]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        [Key]
        [Column(Name = "CaracteristicaId", TypeName = "int", Order = 2)]
        [Required]
        [Display(Name = "Caracteristica Id")]
        public int CaracteristicaId { get; set; }
    }
}
