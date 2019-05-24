using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Red.Repository;
using Red.Domain.Entities;

namespace Red.Repository.Mappings {
    
    
    public class EvangelizadorMap : ClassMap<Evangelizador> {
        
        public EvangelizadorMap() {
			Table("Evangelizador");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			Map(x => x.Nome).Column("Nome").Not.Nullable();
			Map(x => x.Contato).Column("Contato").Not.Nullable();
			Map(x => x.Email).Column("Email").Not.Nullable();

			HasMany(x => x.Turmas).KeyColumn("Evangelizador");

        }
    }
}
