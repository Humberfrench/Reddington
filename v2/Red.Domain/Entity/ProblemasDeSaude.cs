using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Red.Domain.Entity
{
    [Table("ProblemasDeSaude")]
    public class ProblemasDeSaude
    {
        private IList<Aluno> aluno;

        public ProblemasDeSaude()
        {
            aluno = new List<Aluno>();
        }

        [Key]
        public int ProblemasDeSaudeId { get; set; }

        [Required]
        [StringLength(50)]
        public string Descricao { get; set; }

        public virtual IList<Aluno> Aluno
        {
            get => aluno;
            set => aluno = value;
        }
    }
}
