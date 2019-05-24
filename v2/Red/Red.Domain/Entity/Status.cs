using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.EF
{
    public partial class Status
    {
        public Status()
        {
            Aluno = new HashSet<Aluno>();
        }

        public int StatusId { get; set; }
        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        [InverseProperty("Status")]
        public virtual ICollection<Aluno> Aluno { get; set; }
    }
}