using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Evangelizador")]
    public partial class Evangelizador
    {
        private ICollection<Turma> turma;

        public Evangelizador()
        {
            turma = new HashSet<Turma>();
        }

        public int EvangelizadorId { get; set; }

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [StringLength(20)]
        public string Contato { get; set; }

        [Required]
        [StringLength(75)]
        public string Email { get; set; }

        public virtual ICollection<Turma> Turma
        {
            get => turma;
            set => turma = value;
        }
    }
}
