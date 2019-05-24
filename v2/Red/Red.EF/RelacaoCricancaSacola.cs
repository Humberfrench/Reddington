using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("RelacaoCricancaSacola")]
    public class RelacaoCricancaSacola
    {

        [Key]
        [Column(Name = "CriancaSacolaId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Crianca Sacola Id")]
        public int CriancaSacolaId { get; set; }
        [Column(Name = "AlunoId", TypeName = "int")]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        [Column(Name = "CriancaId", TypeName = "int")]
        [Required]
        [Display(Name = "Crianca Id")]
        public int CriancaId { get; set; }
    }
}
