using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Services;

namespace Red.Services
{
    public class EvangelizadorService : ServiceBase<Evangelizador>, IEvangelizadorService
    {
        private readonly IEvangelizadorRepository repEvangelizador;

        public EvangelizadorService(IEvangelizadorRepository repEvangelizador) : base(repEvangelizador)
        {
            this.repEvangelizador = repEvangelizador;
        }
    }
}
