namespace Red.Domain.Entity
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Red")
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AtividadesPreferida> AtividadesPreferida { get; set; }
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Evangelizador> Evangelizador { get; set; }
        public virtual DbSet<ProblemasSaude> ProblemasSaude { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.Sexo)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .Property(e => e.Observacao)
                .IsUnicode(false);

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.AtividadesPreferida)
                .WithMany(e => e.Aluno)
                .Map(m => m.ToTable("AlunoAtividadePreferida").MapLeftKey("AlunoId").MapRightKey("AtividadePreferidaId"));

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Caracteristica)
                .WithMany(e => e.Aluno)
                .Map(m => m.ToTable("AlunoCaracteristica").MapLeftKey("AlunoId").MapRightKey("CaracteristicaId"));

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.ProblemasSaude)
                .WithMany(e => e.Aluno)
                .Map(m => m.ToTable("AlunoProblemaSaude").MapLeftKey("AlunoId").MapRightKey("ProblemaSaudeId"));

            modelBuilder.Entity<Aluno>()
                .HasMany(e => e.Turma)
                .WithMany(e => e.Aluno)
                .Map(m => m.ToTable("AlunoTurma").MapLeftKey("AlunoId").MapRightKey("TurmaId"));

            modelBuilder.Entity<AtividadesPreferida>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Caracteristica>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Evangelizador>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Evangelizador>()
                .Property(e => e.Contato)
                .IsUnicode(false);

            modelBuilder.Entity<Evangelizador>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Evangelizador>()
                .HasMany(e => e.Turma)
                .WithRequired(e => e.Evangelizador)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProblemasSaude>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Responsavel1)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Responsavel2)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Documento)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Endereco)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Bairro)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Cep)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Uf)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Telefone)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Celular1)
                .IsUnicode(false);

            modelBuilder.Entity<Responsavel>()
                .Property(e => e.Celular2)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Status>()
                .HasMany(e => e.Aluno)
                .WithRequired(e => e.Status)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Turma>()
                .Property(e => e.NomeSala)
                .IsUnicode(false);
        }
    }
}
