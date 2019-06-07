using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Application.ViewModel
{
    public partial class CaracteristicaViewModel
    {
        public int CaracteristicaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }
    }
}
