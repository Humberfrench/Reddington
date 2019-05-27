using System;
using Red.Application.Interfaces;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class TurmaServiceApp : BaseServiceApp, ITurmaServiceApp
    {

        private readonly ITurmaService turmaService;

        public TurmaServiceApp(ITurmaService turmaService, IUnitOfWork uow) : base(uow)
        {
            this.turmaService = turmaService;
        }



        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
