using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("AtividadesPreferida")]
    public class AtividadesPreferida
    {

        [Key]
        [Column(Name = "AtividadesPreferidaId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Atividades Preferida Id")]
        public int AtividadesPreferidaId { get; set; }
        [Column(Name = "Descricao", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
