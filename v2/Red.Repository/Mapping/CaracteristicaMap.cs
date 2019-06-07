using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class CaracteristicaMap : EntityTypeConfiguration<Caracteristica>
    {
        public CaracteristicaMap()
        {
            // Primary Key
            this.HasKey(t => t.CaracteristicaId);

            // Table & Column Mappings
            this.ToTable("Caracteristica");
            this.Property(t => t.CaracteristicaId).HasColumnName("CaracteristicaId");
            this.Property(t => t.Descricao).HasColumnName("Descricao");

            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
