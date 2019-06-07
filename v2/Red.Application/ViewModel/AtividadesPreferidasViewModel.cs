using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Application.ViewModel
{
    public partial class AtividadesPreferidasViewModel
    {
        public int AtividadesPreferidasId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
