using System; 
using System.Collections.Generic; 
using System.Text; 
using FluentNHibernate.Mapping;
using Red.Repository;
using Red.Domain.Entities;

namespace Red.Repository.Mappings {
    
    
    public class ResponsavelMap : ClassMap<Responsavel> {
        
        public ResponsavelMap() {
			Table("Responsavel");
			LazyLoad();
			Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
			Map(x => x.Responsavel1).Column("Responsavel1");
			Map(x => x.Responsavel2).Column("Responsavel2");
			Map(x => x.Documento).Column("Documento");
			Map(x => x.Endereco).Column("Endereco");
			Map(x => x.Bairro).Column("Bairro");
			Map(x => x.Cep).Column("Cep");
			Map(x => x.Cidade).Column("Cidade");
			Map(x => x.Uf).Column("Uf");
			Map(x => x.Telefone).Column("Telefone");
			Map(x => x.Celular1).Column("Celular1");
			Map(x => x.Celular2).Column("Celular2");

            HasMany(x => x.Alunos).KeyColumn("Responsavel");

        }
    }
}
