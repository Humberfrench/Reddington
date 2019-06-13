using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using French.Tools.DomainValidator;
using Red.Domain.Entity;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Services;
using French.Tools.Extensions;

namespace Red.Services
{
    public class StatusService : ServiceBase<Status>, IStatusService
    {
        private readonly IStatusRepository repStatus;
        private readonly ValidationResult validationResult;

        public StatusService(IStatusRepository repStatus) : base(repStatus)
        {
            this.repStatus = repStatus;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repStatus.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repStatus.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Status entity)
        {
            if (entity.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }


            var novo = entity.StatusId == 0;
            if (novo)
            {
                repStatus.Adicionar(entity);
            }
            else
            {
                repStatus.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
