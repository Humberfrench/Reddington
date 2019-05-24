using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Caracteristica")]
    public class Caracteristica
    {

        [Key]
        [Column(Name = "CaracteristicaId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Caracteristica Id")]
        public int CaracteristicaId { get; set; }
        [Column(Name = "Descricao", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
