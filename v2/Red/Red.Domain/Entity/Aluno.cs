using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Aluno")]
    public class Aluno
    {

        [Key]
        [Column(Name = "AlunoId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Aluno Id")]
        public int AlunoId { get; set; }
        [Column(Name = "Nome", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Column(Name = "ResponsavelId", TypeName = "int")]
        [Display(Name = "Responsavel Id")]
        public int? ResponsavelId { get; set; }
        [Column(Name = "DataNascimento", TypeName = "date")]
        [Required]
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        [Column(Name = "Sexo", TypeName = "varchar")]
        [MaxLength(1)]
        [StringLength(1)]
        [Required]
        [Display(Name = "Sexo")]
        public string Sexo { get; set; }
        [Column(Name = "GrupoDeJovens", TypeName = "bit")]
        [Required]
        [Display(Name = "Grupo De Jovens")]
        public bool GrupoDeJovens { get; set; }
        [Column(Name = "Matriculado", TypeName = "bit")]
        [Required]
        [Display(Name = "Matriculado")]
        public bool Matriculado { get; set; }
        [Column(Name = "StatusId", TypeName = "int")]
        [Required]
        [Display(Name = "Status Id")]
        public int StatusId { get; set; }
        [Column(Name = "Observacao", TypeName = "varchar")]
        [MaxLength(250)]
        [StringLength(250)]
        [Display(Name = "Observacao")]
        public string Observacao { get; set; }
    }
}
