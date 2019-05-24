using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        private readonly IUnityOfWork UnitWork;
        public StatusRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Status entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Status entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Status entity)
        {
            UnitWork.Excluir(entity);
        }

        public Status ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Status> ObterTodos()
        {
           return base.GetAll();
        }


    }
}
