using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class AlunoMap : EntityTypeConfiguration<Aluno>
    {
        public AlunoMap()
        {
            // Primary Key
            this.HasKey(t => t.AlunoId);

            // Table & Column Mappings
            this.ToTable("Aluno");
            this.Property(t => t.AlunoId).HasColumnName("AlunoId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.ResponsavelId).HasColumnName("ResponsavelId");
            this.Property(t => t.DataNascimento).HasColumnName("DataNascimento");
            this.Property(t => t.GrupoDeJovens).HasColumnName("GrupoDeJovens");
            this.Property(t => t.Matriculado).HasColumnName("Matriculado");
            this.Property(t => t.Observacao).HasColumnName("Observacao");
            this.Property(t => t.Sexo).HasColumnName("Observacao");
            this.Property(t => t.Matriculado).HasColumnName("Matriculado");

            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
