using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class EvangelizadorRepository : Repository<Evangelizador>, IEvangelizadorRepository
    {
        private readonly IUnityOfWork UnitWork;
        public EvangelizadorRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Evangelizador entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Evangelizador entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Evangelizador entity)
        {
            UnitWork.Excluir(entity);
        }

        public Evangelizador ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Evangelizador> ObterTodos()
        {
           return base.GetAll();
        }


    }
}
