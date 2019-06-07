using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("ProblemasDeSaude")]
    public class ProblemasDeSaude
    {

        [Key]
        public int ProblemasDeSaudeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
