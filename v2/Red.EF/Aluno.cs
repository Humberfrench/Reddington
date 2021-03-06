namespace Red.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Aluno")]
    public partial class Aluno
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Aluno()
        {
            AtividadesPreferida = new HashSet<AtividadesPreferida>();
            Caracteristica = new HashSet<Caracteristica>();
            ProblemasSaude = new HashSet<ProblemasSaude>();
            Turma = new HashSet<Turma>();
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AtividadesPreferida> AtividadesPreferida { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Caracteristica> Caracteristica { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProblemasSaude> ProblemasSaude { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Turma> Turma { get; set; }
    }
}
