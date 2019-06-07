using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Responsavel")]
    public partial class Responsavel
    {
        private IList<Aluno> alunos;

        public Responsavel()
        {
            alunos = new List<Aluno>();
        }

        [Key]
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

        public virtual IList<Aluno> Alunos
        {
            get => alunos;
            set => alunos = value;
        }
    }
}
