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
    public class AtividadesPreferidasService : ServiceBase<AtividadesPreferidas>, IAtividadesPreferidasService
    {
        private readonly IAtividadesPreferidasRepository repAtividadesPreferidas;

        public AtividadesPreferidasService(IAtividadesPreferidasRepository repAtividadesPreferidas) : base(repAtividadesPreferidas)
        {
            this.repAtividadesPreferidas = repAtividadesPreferidas;
        }
    }
}
