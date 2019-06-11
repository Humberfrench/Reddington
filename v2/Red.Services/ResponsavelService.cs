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
    public class ResponsavelService : ServiceBase<Responsavel>, IResponsavelService
    {
        private readonly IResponsavelRepository repResponsavel;
        private readonly ValidationResult validationResult;

        public ResponsavelService(IResponsavelRepository repResponsavel) : base(repResponsavel)
        {
            this.repResponsavel = repResponsavel;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repResponsavel.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repResponsavel.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Responsavel entity)
        {
            if (entity.Responsavel1.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Responsável 1.");
                return validationResult;
            }

            if (entity.Responsavel2.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Responsável 2 .");
                return validationResult;
            }

            if (entity.Celular1.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Celular.");
                return validationResult;
            }

            var novo = entity.ResponsavelId == 0;
            if(novo)
            {
                repResponsavel.Adicionar(entity);
            }
            else
            {
                repResponsavel.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
