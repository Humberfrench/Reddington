using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;

namespace Red.Services
{
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository repository;

    }
}
