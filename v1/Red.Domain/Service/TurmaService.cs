using Red.Domain.Entities;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.Domain.ObjectValue;
using Red.DomainValidation;
using System.Collections.Generic;
using System.Linq;

namespace Red.Domain.Service
{
    public class TurmaService : ServiceBase<Turma>, ITurmaService
    {
        private readonly ITurmaRepository turmaRepository;
        private readonly IAlunoRepository alunoRepository;
        private readonly IEvangelizadorRepository evangelizadorRepository;
        private readonly ValidationResult validationResult = new ValidationResult();


        public TurmaService(ITurmaRepository turmaRepository,
                            IEvangelizadorRepository evangelizadorRepository,
                            IAlunoRepository alunoRepository)
            : base(turmaRepository)
        {
            this.turmaRepository = turmaRepository;
            this.evangelizadorRepository = evangelizadorRepository;
            this.alunoRepository = alunoRepository;
        }
        public IEnumerable<Turma> Filtrar(string nome)
        {
            var registros = Pesquisar(p => p.NomeSala.ToLower().Contains(nome.ToLower())).ToList();
            return registros;
        }

        public ValidationResult Gravar(string nome, int ano, int evangelizador)
        {
            var evangelizadorObj = evangelizadorRepository.ObterPorId(evangelizador);
            var turma = new Turma
            {
                Codigo = 0,
                NomeSala = nome,
                Ano = ano,
                Evangelizador = evangelizadorObj
            };

            turmaRepository.Adicionar(turma);

            return validationResult;
        }

        public ValidationResult Atualizar(int turma, string nome)
        {
            var turmaObj = ObterPorId(turma);

            turmaObj.NomeSala = nome;
            turmaRepository.Atualizar(turmaObj);

            return validationResult;
        }

        public ValidationResult Excluir(int id)
        {
            var item = ObterPorId(id);

            if (item == null)
            {
                validationResult.Add(new ValidationError("Registro não encontrado"));
                return validationResult;
            }

            turmaRepository.Excluir(item);

            return validationResult;

        }

        public ValidationResult ExcluirAluno(int idTurma, int idAluno)
        {
            var turma = ObterPorId(idTurma);
            var aluno = turma.Alunos.FirstOrDefault(a => a.Codigo == idAluno);

            turma.Alunos.Remove(aluno);

            turmaRepository.Atualizar(turma);
            return validationResult;

        }

        public Turma ObterTurma(int idEvangelizador, int ano)
        {
            return ObterTodos().FirstOrDefault(t => t.Evangelizador.Codigo == idEvangelizador && t.Ano == ano);
        }

        public ValidationResult AdicionarAlunos(int idTurma, string idAlunos)
        {
            var turma = ObterPorId(idTurma);
            var aAluno = idAlunos.Split(',');
            foreach (string alunoId in aAluno)
            {
                int intAluno;
                if (!int.TryParse(alunoId, out intAluno))
                {
                    validationResult.Add($"Erro ao gravar o aluno de código {alunoId}");
                    return validationResult;
                }
                var aluno = alunoRepository.ObterPorId(intAluno);
                if (aluno == null)
                {
                    validationResult.Add($"Erro ao gravar o aluno de código {alunoId}");
                    return validationResult;
                }
                turma.Alunos.Add(aluno);
            }
            turmaRepository.Atualizar(turma);
            return validationResult;

        }

        public ValidationResult CopiarTurma(int idTurma, int ano, string nome)
        {
            var turmaAtual = turmaRepository.ObterPorId(idTurma);

            if (turmaAtual == null)
            {
                validationResult.Add("Problemas ao copiar a turma");
                return validationResult;
            }

            var turmaNova = turmaAtual;
            turmaNova.Codigo = 0;
            turmaNova.Ano = ano;
            turmaNova.NomeSala = nome;

            turmaRepository.Adicionar(turmaNova);

            return validationResult;
        }


        public IEnumerable<EvangelizadorAluno> ObterPorEvangelizador(int evangelizador, int ano)
        {
            return turmaRepository.ObterPorEvangelizador(evangelizador, ano);
        }

        public IEnumerable<EvangelizadorAluno> ObterTodosPorEvangelizador(int evangelizador, int ano)
        {
            return turmaRepository.ObterTodosPorEvangelizador(evangelizador, ano);
        }

        public IEnumerable<Alunos> ObterAlunosLivres(int ano)
        {
            return turmaRepository.ObterAlunosLivres(ano);
        }

    }
}
