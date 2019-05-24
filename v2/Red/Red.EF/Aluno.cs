using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class Aluno
    {
        public Aluno()
        {
            AlunoAtividadePreferida = new HashSet<AlunoAtividadePreferida>();
            AlunoCaracteristica = new HashSet<AlunoCaracteristica>();
            AlunoProblemaSaude = new HashSet<AlunoProblemaSaude>();
            AlunoTurma = new HashSet<AlunoTurma>();
        }

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

        [ForeignKey("ResponsavelId")]
        [InverseProperty("Aluno")]
        public virtual Responsavel Responsavel { get; set; }
        [ForeignKey("StatusId")]
        [InverseProperty("Aluno")]
        public virtual Status Status { get; set; }
        [InverseProperty("Aluno")]
        public virtual ICollection<AlunoAtividadePreferida> AlunoAtividadePreferida { get; set; }
        [InverseProperty("Aluno")]
        public virtual ICollection<AlunoCaracteristica> AlunoCaracteristica { get; set; }
        [InverseProperty("Aluno")]
        public virtual ICollection<AlunoProblemaSaude> AlunoProblemaSaude { get; set; }
        [InverseProperty("Aluno")]
        public virtual ICollection<AlunoTurma> AlunoTurma { get; set; }
    }
}