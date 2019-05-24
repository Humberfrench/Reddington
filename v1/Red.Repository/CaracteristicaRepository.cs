using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class CaracteristicaRepository : Repository<Caracteristica>, ICaracteristicaRepository
    {            
        private readonly IUnityOfWork UnitWork;
        public CaracteristicaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Caracteristica entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Caracteristica entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Caracteristica entity)
        {
            UnitWork.Excluir(entity);
        }

        public Caracteristica ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Caracteristica> ObterTodos()
        {
           return base.GetAll();
        }


    }
}
