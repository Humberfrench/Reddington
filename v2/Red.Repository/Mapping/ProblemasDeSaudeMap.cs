using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class ProblemasDeSaudeMap : EntityTypeConfiguration<ProblemasDeSaude>
    {
        public ProblemasDeSaudeMap()
        {
            // Primary Key
            this.HasKey(t => t.ProblemasDeSaudeId);

            // Table & Column Mappings
            this.ToTable("ProblemasDeSaude");
            this.Property(t => t.ProblemasDeSaudeId).HasColumnName("ProblemasDeSaudeId");
            this.Property(t => t.Descricao).HasColumnName("Descricao");
            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
