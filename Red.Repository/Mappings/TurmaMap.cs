using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Red.Repository;
using Red.Domain.Entities;

namespace Red.Repository.Mappings {
    
    
    public class TurmaMap : ClassMap<Turma> {
        
        public TurmaMap() {
			Table("Turma");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			References(x => x.Evangelizador).Column("Evangelizador");
			Map(x => x.NomeSala).Column("NomeSala").Not.Nullable();
			Map(x => x.Ano).Column("Ano").Not.Nullable();

            //TurmaLetiva
            HasManyToMany(x => x.Alunos).Table("TurmaLetiva")
                                         .ParentKeyColumn("Turma")
                                         .ChildKeyColumn("Aluno");

        }
    }
}
