using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Turma")]
    public class Turma
    {

        [Key]
        [Column(Name = "TurmaId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Turma Id")]
        public int TurmaId { get; set; }
        [Column(Name = "NomeSala", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Nome Sala")]
        public string NomeSala { get; set; }
        [Column(Name = "EvangelizadorId", TypeName = "int")]
        [Required]
        [Display(Name = "Evangelizador Id")]
        public int EvangelizadorId { get; set; }
        [Column(Name = "Ano", TypeName = "int"), Required, Display(Name = "Ano")]
        public int Ano { get; set; }
    }
}
