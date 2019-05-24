using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("AtividadesPreferida")]
    public partial class AtividadesPreferida
    {
        private IList<Aluno> aluno;

        public AtividadesPreferida()
        {
            aluno = new List<Aluno>();
        }

        public int AtividadesPreferidaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public virtual IList<Aluno> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
