using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class Caracteristica
    {
        public Caracteristica()
        {
            AlunoCaracteristica = new HashSet<AlunoCaracteristica>();
        }

        public int CaracteristicaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty("Caracteristica")]
        public virtual ICollection<AlunoCaracteristica> AlunoCaracteristica { get; set; }
    }
}