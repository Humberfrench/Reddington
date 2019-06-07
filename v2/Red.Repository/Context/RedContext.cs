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
        public virtual DbSet<AtividadesPreferidas> AtividadesPreferidas { get; set; }
        public virtual DbSet<Caracteristica> Caracteristica { get; set; }
        public virtual DbSet<Evangelizador> Evangelizador { get; set; }
        public virtual DbSet<ProblemasDeSaude> ProblemasDeSaude { get; set; }
        public virtual DbSet<Responsavel> Responsavel { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Turma> Turma { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AlunoMap());
            modelBuilder.Configurations.Add(new AtividadesPreferidasMap());
            modelBuilder.Configurations.Add(new CaracteristicaMap());
            modelBuilder.Configurations.Add(new EvangelizadorMap());
            modelBuilder.Configurations.Add(new ProblemasDeSaudeMap());
            modelBuilder.Configurations.Add(new ResponsavelMap());
            modelBuilder.Configurations.Add(new StatusMap());
            modelBuilder.Configurations.Add(new TurmaMap());
        }
    }
}
