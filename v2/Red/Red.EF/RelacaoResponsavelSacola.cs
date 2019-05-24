using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("RelacaoResponsavelSacola")]
    public class RelacaoResponsavelSacola
    {

        [Key]
        [Column(Name = "ResponsavelFamiliaId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Responsavel Familia Id")]
        public int ResponsavelFamiliaId { get; set; }
        [Column(Name = "ResponsavelId", TypeName = "int")]
        [Required]
        [Display(Name = "Responsavel Id")]
        public int ResponsavelId { get; set; }
        [Column(Name = "FamiliaId", TypeName = "int")]
        [Required]
        [Display(Name = "Familia Id")]
        public int FamiliaId { get; set; }
    }
}
