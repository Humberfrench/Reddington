using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class AtividadesPreferidasMap : EntityTypeConfiguration<AtividadesPreferidas>
    {
        public AtividadesPreferidasMap()
        {
            // Primary Key
            this.HasKey(t => t.AtividadesPreferidasId);

            // Table & Column Mappings
            this.ToTable("AtividadesPreferidas");
            this.Property(t => t.AtividadesPreferidasId).HasColumnName("AtividadesPreferidasId");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            //this.HasMany(e => e.Alunos).WithRequired(e => e.AtividadesPreferida).HasForeignKey(e => e.AlunoId).WillCascadeOnDelete(false);
        }
    }
}
