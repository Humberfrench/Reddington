using System.Linq;
using AutoMapper;
using French.Tools.DomainValidator;
using Red.Application.Automapper;
using Red.Domain.Interfaces.Repository.UnitOfWork;

namespace Red.Application.Services
{
    public class BaseServiceApp
    {
        private readonly IUnitOfWork uow;
        protected readonly IMapper Mapper;
        protected ValidationResult ValidationResult;

        public BaseServiceApp(IUnitOfWork uow)
        {
            this.uow = uow;
            AutoMapperConfig.RegisterMappings();
            Mapper = AutoMapperConfig.Config.CreateMapper();
            ValidationResult = new ValidationResult();
        }

        public void BeginTransaction()
        {
            uow.BeginTransaction();
        }

        public void Commit()
        {
            var retorno = uow.SaveChanges();
            if (!retorno.IsValid)
            {
                retorno.Erros.ToList().ForEach(e => ValidationResult.Add(e.Message));
            }
        }
    }
}