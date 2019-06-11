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
    public class AlunoService : ServiceBase<Aluno>, IAlunoService
    {
        private readonly IAlunoRepository repAluno;
        private readonly ValidationResult validationResult;

        public AlunoService(IAlunoRepository repAluno) : base(repAluno)
        {
            this.repAluno = repAluno;
            validationResult = new ValidationResult();
        }

        public ValidationResult Excluir(int id)
        {
            var entity = repAluno.ObterPorId(id);

            if (entity == null)
            {
                validationResult.Add("Registro não encontrado.");
                return validationResult;
            }

            repAluno.Excluir(entity);

            return validationResult;

        }

        public ValidationResult Gravar(Aluno entity)
        {
            if (entity.Nome.IsNullOrEmptyOrWhiteSpace())
            {
                validationResult.Add("Preencher campo Nome.");
                return validationResult;
            }

            if (entity.ResponsavelId == 0)
            {
                validationResult.Add("Preencher campo Responsável 2 .");
                return validationResult;
            }


            var novo = entity.ResponsavelId == 0;
            if (novo)
            {
                repAluno.Adicionar(entity);
            }
            else
            {
                repAluno.Atualizar(entity);
            }

            return validationResult;

        }
    }
}
