using System.Data.Entity;
using Red.Domain.Entity;
using Red.Repository.Mapping;

namespace Red.Repository.Context
{
    public partial class RedContext : DbContext
    {
        public RedContext()
            : base("Name=RedContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
                            
        }
        static RedContext()
        {
            Database.SetInitializer<RedContext>(null);
        }

        public virtual DbSet<Aluno> Alunos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
        }
    }
}
