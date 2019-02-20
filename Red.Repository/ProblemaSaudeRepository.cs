using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class ProblemaSaudeRepository : Repository<ProblemaSaude>, IProblemaSaudeRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ProblemaSaudeRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(ProblemaSaude entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(ProblemaSaude entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(ProblemaSaude entity)
        {
            UnitWork.Excluir(entity);
        }

        public ProblemaSaude ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<ProblemaSaude> ObterTodos()
        {
           return base.GetAll();
        }


    }
}
