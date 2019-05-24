using FluentNHibernate.Mapping;
using Red.Domain.Entities;

namespace Red.Repository.Mappings {


    public class ProblemasSaudeMap : ClassMap<ProblemaSaude>
    {
        
        public ProblemasSaudeMap() {
			Table("ProblemasSaude");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			Map(x => x.Descricao).Column("Descricao").Not.Nullable();

            //AlunoProblemaSaude
            HasManyToMany(x => x.Alunos).Table("AlunoProblemaSaude")
                                         .ParentKeyColumn("ProblemaSaude")
                                         .ChildKeyColumn("Aluno");
        }
    }
}
