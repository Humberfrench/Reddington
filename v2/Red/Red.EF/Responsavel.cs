namespace Red.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Responsavel")]
    public partial class Responsavel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Responsavel()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int ResponsavelId { get; set; }

        [StringLength(75)]
        public string Responsavel1 { get; set; }

        [StringLength(75)]
        public string Responsavel2 { get; set; }

        [StringLength(50)]
        public string Documento { get; set; }

        [StringLength(75)]
        public string Endereco { get; set; }

        [StringLength(30)]
        public string Bairro { get; set; }

        [StringLength(9)]
        public string Cep { get; set; }

        [StringLength(50)]
        public string Cidade { get; set; }

        [StringLength(2)]
        public string Uf { get; set; }

        [StringLength(15)]
        public string Telefone { get; set; }

        [StringLength(15)]
        public string Celular1 { get; set; }

        [StringLength(15)]
        public string Celular2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}
