using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class AtividadesPreferida
    {
        public AtividadesPreferida()
        {
            AlunoAtividadePreferida = new HashSet<AlunoAtividadePreferida>();
        }

        public int AtividadesPreferidaId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty("AtividadePreferida")]
        public virtual ICollection<AlunoAtividadePreferida> AlunoAtividadePreferida { get; set; }
    }
}