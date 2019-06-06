using System;
using System.Collections.Generic;
using French.Tools.DomainValidator;
using Red.Application.Interfaces;
using Red.Application.ViewModel;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;

namespace Red.Application.Services
{
    public class ProblemasDeSaudeServiceApp : BaseServiceApp, IProblemasDeSaudeServiceApp
    {

        private readonly IProblemasDeSaudeService problemaSaudeService;

        public ProblemasDeSaudeServiceApp(IProblemasDeSaudeService problemaSaudeService, IUnitOfWork uow) : base(uow)
        {
            this.problemaSaudeService = problemaSaudeService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<ProblemasDeSaudeViewModel> ObterTodos()
        {
            throw new NotImplementedException();
        }

        public ProblemasDeSaudeViewModel ObterPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Gravar(ProblemasDeSaudeViewModel item)
        {
            throw new NotImplementedException();
        }

        public ValidationResult Excluir(int id)
        {
            throw new NotImplementedException();
        }
    }
}
