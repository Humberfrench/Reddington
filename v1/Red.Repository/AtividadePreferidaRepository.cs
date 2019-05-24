using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class AtividadePreferidaRepository : Repository<AtividadePreferida>, IAtividadePreferidaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public AtividadePreferidaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(AtividadePreferida entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(AtividadePreferida entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(AtividadePreferida entity)
        {
            UnitWork.Excluir(entity);
        }

        public AtividadePreferida ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<AtividadePreferida> ObterTodos()
        {
           return base.GetAll();
        }

    }
}
