using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Evangelizador")]
    public class Evangelizador
    {

        [Key]
        [Column(Name = "EvangelizadorId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Evangelizador Id")]
        public int EvangelizadorId { get; set; }
        [Column(Name = "Nome", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Nome")]
        public string Nome { get; set; }
        [Column(Name = "Contato", TypeName = "varchar")]
        [MaxLength(20)]
        [StringLength(20)]
        [Required]
        [Display(Name = "Contato")]
        public string Contato { get; set; }
        [Column(Name = "Email", TypeName = "varchar")]
        [MaxLength(75)]
        [StringLength(75)]
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
