using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class ResponsavelRepository : Repository<Responsavel>, IResponsavelRepository
    {
        private readonly IUnityOfWork UnitWork;
        public ResponsavelRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Responsavel entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Responsavel entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Responsavel entity)
        {
            UnitWork.Excluir(entity);
        }

        public Responsavel ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Responsavel> ObterTodos()
        {
           return base.GetAll();
        }


    }
}
