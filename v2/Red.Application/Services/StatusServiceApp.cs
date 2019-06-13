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
    public class StatusServiceApp : BaseServiceApp, IStatusServiceApp
    {

        private readonly IStatusService statusService;

        public StatusServiceApp(IStatusService statusService, IUnitOfWork uow) : base(uow)
        {
            this.statusService = statusService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<StatusViewModel> ObterTodos()
        {
            var dados = statusService.ObterTodos();

            var retorno = Mapper.Map<IList<StatusViewModel>>(dados);

            return retorno;
        }

        public StatusViewModel ObterPorId(int id)
        {
            var dados = statusService.ObterPorId(id);

            var retorno = Mapper.Map<StatusViewModel>(dados);

            return retorno;
        }

        public ValidationResult Gravar(StatusViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
