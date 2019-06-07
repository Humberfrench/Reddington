using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class TurmaMap : EntityTypeConfiguration<Turma>
    {
        public TurmaMap()
        {
            // Primary Key
            this.HasKey(t => t.TurmaId);

            // Table & Column Mappings
            this.ToTable("Turma");
            this.Property(t => t.TurmaId).HasColumnName("TurmaId");
            this.Property(t => t.NomeSala).HasColumnName("NomeSala");
            this.Property(t => t.EvangelizadorId).HasColumnName("ResponsavelId");
            this.Property(t => t.Ano).HasColumnName("DataNascimento");

            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
