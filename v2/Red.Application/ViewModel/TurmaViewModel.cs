using System.Collections.Generic;

namespace Red.Application.ViewModel
{
    public partial class TurmaViewModel
    {
        public int TurmaId { get; set; }

        public string NomeSala { get; set; }

        public int EvangelizadorId { get; set; }

        public int Ano { get; set; }

        public virtual EvangelizadorViewModel Evangelizador { get; set; }

    }
}
