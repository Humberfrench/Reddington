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
    public class ResponsavelServiceApp : BaseServiceApp, IResponsavelServiceApp
    {

        private readonly IResponsavelService responsavelService;

        public ResponsavelServiceApp(IResponsavelService responsavelService, IUnitOfWork uow) : base(uow)
        {
            this.responsavelService = responsavelService;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public IList<ResponsavelViewModel> ObterTodos()
        {
            var dados = responsavelService.ObterTodos();

            var retorno = Mapper.Map<IList<ResponsavelViewModel>>(dados);

            return retorno;
        }
        public ResponsavelViewModel ObterPorId(int id)
        {
            var dados = responsavelService.ObterPorId(id);

            var retorno = Mapper.Map<ResponsavelViewModel>(dados);

            return retorno;
        }

        public ValidationResult Gravar(ResponsavelViewModel item)
        {
            var entity = Mapper.Map<Responsavel>(item);

            var retorno = responsavelService.Gravar(entity);

            if (retorno.IsValid)
            {
                Commit();
                if (!ValidationResult.IsValid)
                {
                    return ValidationResult;
                }
            }
            return retorno;

        }

        public ValidationResult Excluir(int id)
        {
            var retorno = responsavelService.Excluir(id);
            if (retorno.IsValid)
            {
                Commit();
                if (!ValidationResult.IsValid)
                {
                    return ValidationResult;
                }
            }
            return retorno;

        }
    }
}
