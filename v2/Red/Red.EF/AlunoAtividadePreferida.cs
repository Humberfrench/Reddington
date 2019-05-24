using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class AlunoAtividadePreferida
    {
        public int AlunoId { get; set; }
        public int AtividadePreferidaId { get; set; }

        [ForeignKey("AlunoId")]
        [InverseProperty("AlunoAtividadePreferida")]
        public virtual Aluno Aluno { get; set; }
        [ForeignKey("AtividadePreferidaId")]
        [InverseProperty("AlunoAtividadePreferida")]
        public virtual AtividadesPreferida AtividadePreferida { get; set; }
    }
}