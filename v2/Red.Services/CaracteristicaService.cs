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
    public class CaracteristicaService : ServiceBase<Caracteristica>, ICaracteristicaService
    {
        private readonly ICaracteristicaRepository repCaracteristica;
        private readonly ValidationResult validationResult;

        public CaracteristicaService(ICaracteristicaRepository repCaracteristica) : base(repCaracteristica)
        {
            this.repCaracteristica = repCaracteristica;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repCaracteristica.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repCaracteristica.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Caracteristica entity)
        {
            if (entity.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }

            var novo = entity.CaracteristicaId == 0;
            if (novo)
            {
                repCaracteristica.Adicionar(entity);
            }
            else
            {
                repCaracteristica.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
