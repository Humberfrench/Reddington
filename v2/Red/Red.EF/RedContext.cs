using System;
using System.Data.Entity;

namespace Red.EF
{
    public partial class RedContext : DbContext
    {
        public RedContext()
        {
        }

        public virtual DbSet<Aluno> Alunoes { get; set; }

        public virtual DbSet<AlunoAtividadePreferida> AlunoAtividadePreferidas { get; set; }

        public virtual DbSet<AlunoCaracteristica> AlunoCaracteristicas { get; set; }

        public virtual DbSet<AlunoProblemaSaude> AlunoProblemaSaudes { get; set; }

        public virtual DbSet<AlunoTurma> AlunoTurmas { get; set; }

        public virtual DbSet<AtividadesPreferida> AtividadesPreferidas { get; set; }

        public virtual DbSet<Caracteristica> Caracteristicas { get; set; }

        public virtual DbSet<Evangelizador> Evangelizadors { get; set; }

        public virtual DbSet<ProblemasSaude> ProblemasSaudes { get; set; }

        public virtual DbSet<RelacaoCricancaSacola> RelacaoCricancaSacolas { get; set; }

        public virtual DbSet<RelacaoResponsavelSacola> RelacaoResponsavelSacolas { get; set; }

        public virtual DbSet<Responsavel> Responsavels { get; set; }

        public virtual DbSet<Status> Status { get; set; }

        public virtual DbSet<Turma> Turmas { get; set; }


    }
}