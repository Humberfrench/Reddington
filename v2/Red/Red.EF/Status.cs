using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Status")]
    public class Status
    {

        [Key]
        [Column(Name = "StatusId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Status Id")]
        public int StatusId { get; set; }
        [Column(Name = "Descricao", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Required]
        [Display(Name = "Descricao")]
        public string Descricao { get; set; }
    }
}
