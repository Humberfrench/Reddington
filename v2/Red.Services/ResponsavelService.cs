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
    public class ResponsavelService : ServiceBase<Responsavel>, IResponsavelService
    {
        private readonly IResponsavelRepository repResponsavel;

        public ResponsavelService(IResponsavelRepository repResponsavel) : base(repResponsavel)
        {
            this.repResponsavel = repResponsavel;
        }
    }
}
