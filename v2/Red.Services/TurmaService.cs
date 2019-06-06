﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Services;

namespace Red.Services
{
    public class TurmaService : ServiceBase<Turma>, ITurmaService
    {
        private readonly ITurmaRepository repTurma;

        public TurmaService(ITurmaRepository repTurma) : base(repTurma)
        {
            this.repTurma = repTurma;
        }
    }
}