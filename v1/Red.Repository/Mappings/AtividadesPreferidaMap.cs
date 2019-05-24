using FluentNHibernate.Mapping;
using Red.Domain.Entities;

namespace Red.Repository.Mappings
{


    public class AtividadesPreferidaMap : ClassMap<AtividadePreferida>
    {

        public AtividadesPreferidaMap()
        {
            Table("AtividadesPreferida");
            LazyLoad();
            Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();

            //AlunoAtividadePreferida
            HasManyToMany(x => x.Alunos).Table("AlunoAtividadePreferida")
                                         .ParentKeyColumn("AtividadePreferida")
                                         .ChildKeyColumn("Aluno");
        }
    }
}
