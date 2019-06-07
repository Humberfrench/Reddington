using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Red.Application.ViewModel
{
    public class ProblemasDeSaudeViewModel
    {
        public int ProblemasDeSaudeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

    }
}
