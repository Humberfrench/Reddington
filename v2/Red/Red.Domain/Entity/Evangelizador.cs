using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class Evangelizador
    {
        public Evangelizador()
        {
            Turma = new HashSet<Turma>();
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

        [InverseProperty("Evangelizador")]
        public virtual ICollection<Turma> Turma { get; set; }
    }
}