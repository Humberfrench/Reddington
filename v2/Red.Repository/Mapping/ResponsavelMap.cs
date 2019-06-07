using System.Data.Entity.ModelConfiguration;
using Red.Domain.Entity;

namespace Red.Repository.Mapping
{
    public class ResponsavelMap : EntityTypeConfiguration<Responsavel>
    {
        public ResponsavelMap()
        {
            // Primary Key
            this.HasKey(t => t.ResponsavelId);

            // Table & Column Mappings
            this.ToTable("Responsavel");
            this.Property(t => t.ResponsavelId).HasColumnName("ResponsavelId");
            this.Property(t => t.Responsavel1).HasColumnName("Responsavel1");
            this.Property(t => t.Responsavel2).HasColumnName("Responsavel2");
            this.Property(t => t.Documento).HasColumnName("Documento");
            this.Property(t => t.Endereco).HasColumnName("Endereco");
            this.Property(t => t.Bairro).HasColumnName("Bairro");
            this.Property(t => t.Cep).HasColumnName("Cep");
            this.Property(t => t.Cidade).HasColumnName("Cidade");
            this.Property(t => t.Uf).HasColumnName("Uf");
            this.Property(t => t.Telefone).HasColumnName("Telefone");
            this.Property(t => t.Celular1).HasColumnName("Celular1");
            this.Property(t => t.Celular2).HasColumnName("Celular2");

            //this.HasMany(e => e.Favorecidos).WithRequired(e => e.Banco).HasForeignKey(e => e.BancoId).WillCascadeOnDelete(false);
        }
    }
}
