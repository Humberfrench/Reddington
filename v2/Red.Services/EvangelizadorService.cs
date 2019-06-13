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
    public class EvangelizadorService : ServiceBase<Evangelizador>, IEvangelizadorService
    {
        private readonly IEvangelizadorRepository repEvangelizador;
        private readonly ValidationResult validationResult;

        public EvangelizadorService(IEvangelizadorRepository repEvangelizador) : base(repEvangelizador)
        {
            this.repEvangelizador = repEvangelizador;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repEvangelizador.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repEvangelizador.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Evangelizador entity)
        {
            if (entity.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }

            var novo = entity.EvangelizadorId == 0;
            if (novo)
            {
                repEvangelizador.Adicionar(entity);
            }
            else
            {
                repEvangelizador.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
