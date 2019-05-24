
namespace Red.Application.ViewModel.DTO
{
    public class DTOEvangelizadorAluno
    {
        public DTOEvangelizadorAluno()
        {

        }

        public virtual int Codigo { get; set; }
        public virtual string Evangelizador { get; set; }
        public virtual string Turma { get; set; }
        public virtual int Ano { get; set; }
        public virtual string Aluno { get; set; }
        public virtual int Idade { get; set; }  
        public virtual string Status { get; set; }
        public virtual int TurmaCodigo { get; set; }

    }
}
