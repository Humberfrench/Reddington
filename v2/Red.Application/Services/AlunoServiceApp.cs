using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class AlunoServiceApp : BaseServiceApp, IAlunoServiceApp
    {
        private readonly IAlunoService alunoService;

        public AlunoServiceApp(IAlunoService alunoService, IUnitOfWork uow) : base(uow)
        {
            this.alunoService = alunoService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}

