using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Aluno")]
    public partial class Aluno
    {
        private IList<AtividadesPreferida> atividadesPreferida;
        private IList<Caracteristica> caracteristica;
        private IList<ProblemasSaude> problemasSaude;
        private IList<Turma> turma;

        public Aluno()
        {
            atividadesPreferida = new List<AtividadesPreferida>();
            caracteristica = new List<Caracteristica>();
            problemasSaude = new List<ProblemasSaude>();
            turma = new List<Turma>();
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

        public virtual Responsavel Responsavel { get; set; }

        public virtual Status Status { get; set; }

        public virtual IList<AtividadesPreferida> AtividadesPreferida
        {
            get => atividadesPreferida;
            set => atividadesPreferida = value;
        }

        public virtual IList<Caracteristica> Caracteristica
        {
            get => caracteristica;
            set => caracteristica = value;
        }

        public virtual IList<ProblemasSaude> ProblemasSaude
        {
            get => problemasSaude;
            set => problemasSaude = value;
        }

        public virtual IList<Turma> Turma
        {
            get => turma;
            set => turma = value;
        }
    }
}
