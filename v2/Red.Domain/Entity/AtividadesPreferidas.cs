using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("AtividadesPreferida")]
    public partial class AtividadesPreferidas
    {

        [Key]
        public int AtividadesPreferidasId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
