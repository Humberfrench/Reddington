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
    public class StatusService : ServiceBase<Status>, IStatusService
    {
        private readonly IStatusRepository repStatus;

        public StatusService(IStatusRepository repStatus) : base(repStatus)
        {
            this.repStatus = repStatus;
        }
    }
}
