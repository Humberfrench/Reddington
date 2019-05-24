using System;
using System.Data.Entity.ModelConfiguration;

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    [Table("Responsavel")]
    public class Responsavel
    {

        [Key]
        [Column(Name = "ResponsavelId", TypeName = "int")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Display(Name = "Responsavel Id")]
        public int ResponsavelId { get; set; }
        [Column(Name = "Responsavel1", TypeName = "varchar")]
        [MaxLength(75)]
        [StringLength(75)]
        [Display(Name = "Responsavel1")]
        public string Responsavel1 { get; set; }
        [Column(Name = "Responsavel2", TypeName = "varchar")]
        [MaxLength(75)]
        [StringLength(75)]
        [Display(Name = "Responsavel2")]
        public string Responsavel2 { get; set; }
        [Column(Name = "Documento", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Documento")]
        public string Documento { get; set; }
        [Column(Name = "Endereco", TypeName = "varchar")]
        [MaxLength(75)]
        [StringLength(75)]
        [Display(Name = "Endereco")]
        public string Endereco { get; set; }
        [Column(Name = "Bairro", TypeName = "varchar")]
        [MaxLength(30)]
        [StringLength(30)]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }
        [Column(Name = "Cep", TypeName = "varchar")]
        [MaxLength(9)]
        [StringLength(9)]
        [Display(Name = "Cep")]
        public string Cep { get; set; }
        [Column(Name = "Cidade", TypeName = "varchar")]
        [MaxLength(50)]
        [StringLength(50)]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }
        [Column(Name = "Uf", TypeName = "varchar")]
        [MaxLength(2)]
        [StringLength(2)]
        [Display(Name = "Uf")]
        public string Uf { get; set; }
        [Column(Name = "Telefone", TypeName = "varchar")]
        [MaxLength(15)]
        [StringLength(15)]
        [Display(Name = "Telefone")]
        public string Telefone { get; set; }
        [Column(Name = "Celular1", TypeName = "varchar")]
        [MaxLength(15)]
        [StringLength(15)]
        [Display(Name = "Celular1")]
        public string Celular1 { get; set; }
        [Column(Name = "Celular2", TypeName = "varchar")]
        [MaxLength(15)]
        [StringLength(15)]
        [Display(Name = "Celular2")]
        public string Celular2 { get; set; }
    }
}
