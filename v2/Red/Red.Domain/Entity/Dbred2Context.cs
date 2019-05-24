using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Red.EF
{
    public partial class Dbred2Context : DbContext
    {
        public Dbred2Context()
        {
        }

        public Dbred2Context(DbContextOptions<Dbred2Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Aluno> Aluno { get; set; }
        public virtual DbSet<AlunoAtividadePreferida> AlunoAtividadePreferida { get; set; }
        public virtual DbSet<AlunoCaracteristica> AlunoCaracteristica { get; set; }
        public virtual DbSet<AlunoProblemaSaude> AlunoProblemaSaude { get; set; }
        public virtual DbSet<AlunoTurma> AlunoTurma { get; set; }
        public virtual DbSet<AtividadesPreferida> AtividadesPreferida { get; set; }
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Evangelizador> Evangelizador { get; set; }
        public virtual DbSet<ProblemasSaude> ProblemasSaude { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=.\\WEB16;Initial Catalog=dbRed2;Persist Security Info=True;User ID=sa;Password=123456");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Aluno>(entity =>
            {
                entity.Property(e => e.Nome).IsUnicode(false);

                entity.Property(e => e.Observacao).IsUnicode(false);

                entity.Property(e => e.Sexo).IsUnicode(false);

                entity.HasOne(d => d.Responsavel)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.ResponsavelId)
                    .HasConstraintName("FK_Aluno_Responsavel");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Aluno)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Aluno_Status");
            });

            modelBuilder.Entity<AlunoAtividadePreferida>(entity =>
            {
                entity.HasKey(e => new { e.AlunoId, e.AtividadePreferidaId })
                    .HasName("PK_AlunoAtividade");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.AlunoAtividadePreferida)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoAtividadePreferida_Aluno");

                entity.HasOne(d => d.AtividadePreferida)
                    .WithMany(p => p.AlunoAtividadePreferida)
                    .HasForeignKey(d => d.AtividadePreferidaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoAtividadePreferida_AtividadesPreferida");
            });

            modelBuilder.Entity<AlunoCaracteristica>(entity =>
            {
                entity.HasKey(e => new { e.AlunoId, e.CaracteristicaId });

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.AlunoCaracteristica)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoCaracteristica_Aluno");

                entity.HasOne(d => d.Caracteristica)
                    .WithMany(p => p.AlunoCaracteristica)
                    .HasForeignKey(d => d.CaracteristicaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoCaracteristica_Caracteristica");
            });

            modelBuilder.Entity<AlunoProblemaSaude>(entity =>
            {
                entity.HasKey(e => new { e.AlunoId, e.ProblemaSaudeId });

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.AlunoProblemaSaude)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoProblemaSaude_Aluno");

                entity.HasOne(d => d.ProblemaSaude)
                    .WithMany(p => p.AlunoProblemaSaude)
                    .HasForeignKey(d => d.ProblemaSaudeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoProblemaSaude_ProblemasSaude");
            });

            modelBuilder.Entity<AlunoTurma>(entity =>
            {
                entity.HasKey(e => new { e.TurmaId, e.AlunoId })
                    .HasName("PK_TurmaLetiva");

                entity.HasOne(d => d.Aluno)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.AlunoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoTurma_Aluno");

                entity.HasOne(d => d.Turma)
                    .WithMany(p => p.AlunoTurma)
                    .HasForeignKey(d => d.TurmaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AlunoTurma_Turma");
            });

            modelBuilder.Entity<AtividadesPreferida>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Caracteristica>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Evangelizador>(entity =>
            {
                entity.Property(e => e.Contato).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nome).IsUnicode(false);
            });

            modelBuilder.Entity<ProblemasSaude>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Responsavel>(entity =>
            {
                entity.Property(e => e.Bairro).IsUnicode(false);

                entity.Property(e => e.Celular1).IsUnicode(false);

                entity.Property(e => e.Celular2).IsUnicode(false);

                entity.Property(e => e.Cep).IsUnicode(false);

                entity.Property(e => e.Cidade).IsUnicode(false);

                entity.Property(e => e.Documento).IsUnicode(false);

                entity.Property(e => e.Endereco).IsUnicode(false);

                entity.Property(e => e.Responsavel1).IsUnicode(false);

                entity.Property(e => e.Responsavel2).IsUnicode(false);

                entity.Property(e => e.Telefone).IsUnicode(false);

                entity.Property(e => e.Uf).IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Descricao).IsUnicode(false);
            });

            modelBuilder.Entity<Turma>(entity =>
            {
                entity.Property(e => e.NomeSala).IsUnicode(false);

                entity.HasOne(d => d.Evangelizador)
                    .WithMany(p => p.Turma)
                    .HasForeignKey(d => d.EvangelizadorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Turma_Evangelizador");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}