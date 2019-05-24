using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class AlunoCaracteristica
    {
        public int AlunoId { get; set; }
        public int CaracteristicaId { get; set; }

        [ForeignKey("AlunoId")]
        [InverseProperty("AlunoCaracteristica")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("CaracteristicaId")]
        [InverseProperty("AlunoCaracteristica")]
        public virtual Caracteristica Caracteristica { get; set; }
    }
}