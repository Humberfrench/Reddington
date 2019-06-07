using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class StatusMap : EntityTypeConfiguration<Status>
    {
        public StatusMap()
        {
            // Primary Key
            this.HasKey(t => t.StatusId);

            // Table & Column Mappings
            this.ToTable("Status");
            this.Property(t => t.StatusId).HasColumnName("StatusId");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
