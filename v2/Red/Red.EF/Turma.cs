namespace Red.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Turma")]
    public partial class Turma
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Turma()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int TurmaId { get; set; }

        [Required]
        [StringLength(50)]
        public string NomeSala { get; set; }

        public int EvangelizadorId { get; set; }

        public int Ano { get; set; }

        public virtual Evangelizador Evangelizador { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
