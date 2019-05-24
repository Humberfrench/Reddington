using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class ProblemasSaude
    {
        public ProblemasSaude()
        {
            AlunoProblemaSaude = new HashSet<AlunoProblemaSaude>();
        }

        [Key]
        public int ProblemaDeSaudeId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty("ProblemaSaude")]
        public virtual ICollection<AlunoProblemaSaude> AlunoProblemaSaude { get; set; }
    }
}