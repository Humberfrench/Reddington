using Dapper;
using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Repository.UnityOfWork;
using System.Collections.Generic;
using Red.Domain.ObjectValue;

namespace Red.Repository
{
    public class TurmaRepository : Repository<Turma>, ITurmaRepository
    {
        private readonly IUnityOfWork UnitWork;
        public TurmaRepository(IUnityOfWork unitWork)
            : base(unitWork)
        {
            UnitWork = unitWork;
        }

        public void Adicionar(Turma entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Atualizar(Turma entity)
        {
            UnitWork.Salvar(entity);
        }

        public void Excluir(Turma entity)
        {
            UnitWork.Excluir(entity);
        }

        public Turma ObterPorId(int id)
        {
            return base.GetById(id);
        }

        public IEnumerable<Turma> ObterTodos()
        {
            return base.GetAll();
        }

        public IEnumerable<EvangelizadorAluno> ObterPorEvangelizador(int evangelizador, int ano)
        {
            var sql = @"SELECT  al.Codigo, ev.Nome 'Evangelizador' , al.Nome 'Aluno', 
	                            datediff(YEAR, DataNascimento, GETDATE()) 'Idade', 
	                            tu.Ano, tu.NomeSala 'Turma', st.Descricao 'Status',
                                tu.Codigo TurmaCodigo
                        FROM	Aluno al
                        JOIN	TurmaLetiva tl
                        ON		tl.Aluno = al.Codigo
                        JOIN	Turma tu
                        ON		tl.Turma = tu.Codigo
                        JOIN	Evangelizador ev
                        ON		tu.Evangelizador = ev.Codigo
                        AND     ev.Codigo = @evangelizador
                        AND     tu.Ano = @ano
                        JOIN    Status st
                        ON      al.Status = st.Codigo
                        WHERE   al.Status in (1,2,6) 
                        ORDER BY	ev.Nome";

            var result = Session.Connection.Query<EvangelizadorAluno>(sql,
                new { evangelizador, ano });

            return result;

        }

        public IEnumerable<EvangelizadorAluno> ObterTodosPorEvangelizador(int evangelizador, int ano)
        {
            var sql = @"SELECT  al.Codigo, ev.Nome 'Evangelizador' , al.Nome 'Aluno', 
	                            datediff(YEAR, DataNascimento, GETDATE()) 'Idade', 
	                            tu.Ano, tu.NomeSala 'Turma', st.Descricao 'Status',
                                tu.Codigo TurmaCodigo
                        FROM	Aluno al
                        JOIN	TurmaLetiva tl
                        ON		tl.Aluno = al.Codigo
                        JOIN	Turma tu
                        ON		tl.Turma = tu.Codigo
                        JOIN	Evangelizador ev
                        ON		tu.Evangelizador = ev.Codigo
                        AND     ev.Codigo = @evangelizador
                        AND     tu.Ano = @ano
                        JOIN    Status st
                        ON      al.Status = st.Codigo
                        ORDER BY	ev.Nome";

            var result = Session.Connection.Query<EvangelizadorAluno>(sql,
                new { evangelizador, ano });

            return result;

        }


        public IEnumerable<Alunos> ObterAlunosLivres(int ano)
        {
            var sql = @"SELECT  DISTINCT al.Codigo, al.Nome, 
	                            datediff(YEAR, DataNascimento, GETDATE()) 'Idade', 
	                             st.Descricao 'Status'
                        FROM	Aluno al
                        JOIN    Status st
                        ON      al.Status = st.Codigo
                        WHERE   al.Status in (1,2,6) 
                        AND		al.Codigo NOT IN (
		                        Select tl1.Aluno 
		                        FROM TurmaLetiva tl1
		                        JOIN Turma tu1
		                        ON   tl1.Turma = tu1.Codigo
		                        AND  tu1.Ano = @ano )
                        ORDER BY	ev.Nome ";

            var result = Session.Connection.Query<Alunos>(sql,
                new { ano });

            return result;

        }


    }
}
