using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using Red.Domain.Models.Mapping;

namespace Red.Domain.Models
{
    public partial class dbRContext : DbContext
    {
        static dbRContext()
        {
            Database.SetInitializer<dbRContext>(null);
        }

        public dbRContext()
            : base("Name=dbRContext")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
