using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class EvangelizadorMap : EntityTypeConfiguration<Evangelizador>
    {
        public EvangelizadorMap()
        {
            // Primary Key
            this.HasKey(t => t.EvangelizadorId);

            // Table & Column Mappings
            this.ToTable("Evangelizador");
            this.Property(t => t.EvangelizadorId).HasColumnName("EvangelizadorId");
            this.Property(t => t.Nome).HasColumnName("Nome");
            this.Property(t => t.Contato).HasColumnName("Contato");
            this.Property(t => t.Email).HasColumnName("Email");

            this.HasMany(e => e.Turmas).WithRequired(e => e.Evangelizador).HasForeignKey(e => e.EvangelizadorId).WillCascadeOnDelete(false);
        }
    }
}
