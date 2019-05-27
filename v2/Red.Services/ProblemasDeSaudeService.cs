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
    public class ProblemasDeSaudeService : ServiceBase<ProblemasDeSaude>, IProblemasDeSaudeService
    {
        private readonly IProblemasDeSaudeRepository repProblemasDeSaude;

        public ProblemasDeSaudeService(IProblemasDeSaudeRepository repProblemasDeSaude) : base(repProblemasDeSaude)
        {
            this.repProblemasDeSaude = repProblemasDeSaude;
        }
    }
}
