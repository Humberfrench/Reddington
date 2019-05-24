using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("ProblemasSaude")]
    public class ProblemasSaude
    {

        [Key]
        [Column(Name = "ProblemaDeSaudeId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Problema De Saude Id")]
        public int ProblemaDeSaudeId { get; set; }
        [Column(Name = "Descricao", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
