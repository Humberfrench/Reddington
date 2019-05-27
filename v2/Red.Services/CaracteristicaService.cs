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
    public class CaracteristicaService : ServiceBase<Caracteristica>, ICaracteristicaService
    {
        private readonly ICaracteristicaRepository repCaracteristica;

        public CaracteristicaService(ICaracteristicaRepository repCaracteristica) : base(repCaracteristica)
        {
            this.repCaracteristica = repCaracteristica;
        }
    }
}
