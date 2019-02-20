using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Red.Repository;
using Red.Domain.Entities;

namespace Red.Repository.Mappings {
    
    
    public class StatusMap : ClassMap<Status> {
        
        public StatusMap() {
			Table("Status");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			Map(x => x.Descricao).Column("Descricao").Not.Nullable();

			HasMany(x => x.Alunos).KeyColumn("Status");
        }
    }
}
