using System;
using System.Collections.Generic;
using System.Text;
using FluentNHibernate.Mapping;
using Red.Repository;
using Red.Domain.Entities;

namespace Red.Repository.Mappings
{


    public class CaracteristicaMap : ClassMap<Caracteristica>
    {

        public CaracteristicaMap()
        {
            Table("Caracteristica");
            LazyLoad();
            Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
            Map(x => x.Descricao).Column("Descricao").Not.Nullable();
            
            //AlunoCaracteristica
            HasManyToMany(x => x.Alunos).Table("AlunoCaracteristica")
                                         .ParentKeyColumn("Caracteristica")
                                         .ChildKeyColumn("Aluno");
        }
    }
}
