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
    public class ProblemasDeSaudeService : ServiceBase<ProblemasDeSaude>, IProblemasDeSaudeService
    {
        private readonly IProblemasDeSaudeRepository repProblemasDeSaude;
        private readonly ValidationResult validationResult;

        public ProblemasDeSaudeService(IProblemasDeSaudeRepository repProblemasDeSaude) : base(repProblemasDeSaude)
        {
            this.repProblemasDeSaude = repProblemasDeSaude;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repProblemasDeSaude.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repProblemasDeSaude.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(ProblemasDeSaude entity)
        {
            if (entity.Descricao.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }

            var novo = entity.ProblemasDeSaudeId == 0;
            if (novo)
            {
                repProblemasDeSaude.Adicionar(entity);
            }
            else
            {
                repProblemasDeSaude.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
