using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Aluno")]
    public partial class Aluno
    {

        [Key]
        public int AlunoId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        public int? ResponsavelId { get; set; }

        [Column(TypeName = "date")]
        public DateTime DataNascimento { get; set; }

        [Required]
        [StringLength(1)]
        public string Sexo { get; set; }

        public bool GrupoDeJovens { get; set; }

        public bool Matriculado { get; set; }

        public int StatusId { get; set; }

        [StringLength(250)]
        public string Observacao { get; set; }

        public virtual Responsavel Responsavel { get; set; }

        public virtual Status Status { get; set; }

    }
}
