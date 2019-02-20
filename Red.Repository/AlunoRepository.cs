using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;

namespace Red.Repository
{
    public class AlunoRepository : Repository<Aluno>, IAlunoRepository
    {
        private readonly IUnityOfWork UnitWork;
        public AlunoRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Aluno entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Aluno entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Aluno entity)
        {
            UnitWork.Excluir(entity);
        }

        public Aluno ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Aluno> ObterTodos()
        {
            return base.GetAll();
        }

        //        public IList<EmpresaAplicacaoCliente> ObterTodosPorUsuarioCliente(long usuario, long cliente)
        //        {
        //            string sql = @"SELECT	eac.*, eap.*, emp.*, app.* 
        //                            FROM	EmpresaAplicacaoCliente as eac 
        //                            JOIN	EmpresaAplicacao as eap
        //                            ON		eac.EmpresaAplicacaoId = eap.EmpresaAplicacaoId
        //                            JOIN	Empresa as emp
        //                            ON		emp.EmpresaId = eap.EmpresaId
        //                            JOIN	Aplicacao as app
        //                            ON		app.AplicacaoId = eap.AplicacaoId  
        //                           WHERE    eac.ClienteId = @cliente
        //                           AND		" + FiltroSql.ObterFiltroAplicacaoCliente("eap", usuario);
        //            var result = Connection.Query<EmpresaAplicacaoCliente,EmpresaAplicacao, Empresa, Aplicacao, EmpresaAplicacaoCliente>(sql,
        //                (eac, eap, emp, app) =>
        //                {
        //                    eac.EmpresaAplicacao = eap;
        //                    eap.Empresa = emp;
        //                    eap.Aplicacao = app;
        //                    return eac;
        //                },
        //                new { @cliente = cliente },
        //                splitOn: "EmpresaAplicacaoClienteId,EmpresaAplicacaoId,EmpresaId,AplicacaoId");

        //            return result.ToList();

        //    }

    }
}