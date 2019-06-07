using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("Caracteristica")]
    public partial class Caracteristica
    {

        [Key]
        public int CaracteristicaId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
