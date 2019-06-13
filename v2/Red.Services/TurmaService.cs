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
    public class TurmaService : ServiceBase<Turma>, ITurmaService
    {
        private readonly ITurmaRepository repTurma;
        private readonly ValidationResult validationResult;

        public TurmaService(ITurmaRepository repTurma) : base(repTurma)
        {
            this.repTurma = repTurma;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repTurma.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repTurma.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Turma entity)
        {

            var novo = entity.TurmaId == 0;
            if (novo)
            {
                repTurma.Adicionar(entity);
            }
            else
            {
                repTurma.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
