using FluentNHibernate.Mapping;
using Red.Domain.Entities;

namespace Red.Repository.Mappings
{

    public class AlunoMap : ClassMap<Aluno>
    {

        public AlunoMap()
        {
            Table("Aluno");
            LazyLoad();
            Id(x => x.Codigo).GeneratedBy.Identity().Column("Codigo");
            Map(x => x.Nome).Column("Nome").Not.Nullable();
            Map(x => x.DataNascimento).Column("DataNascimento").Not.Nullable();
            Map(x => x.GrupoDeJovens).Column("GrupoDeJovens").Not.Nullable();
            Map(x => x.Matriculado).Column("Matriculado");
            Map(x => x.Observacao).Column("Observacao");
            References(x => x.Status).Column("Status");
            References(x => x.Responsavel).Column("Responsavel");

            //AlunoCaracteristica
            HasManyToMany(x => x.Caracteristicas).Table("AlunoCaracteristica")
                                         .ParentKeyColumn("Aluno")
                                         .ChildKeyColumn("Caracteristica");

            //AlunoAtividadePreferida
            HasManyToMany(x => x.AtividadesPreferidas).Table("AlunoAtividadePreferida")
                                         .ParentKeyColumn("Aluno")
                                         .ChildKeyColumn("AtividadePreferida");

            //AlunoProblemaSaude
            HasManyToMany(x => x.ProblemasSaude).Table("AlunoProblemaSaude")
                                         .ParentKeyColumn("Aluno")
                                         .ChildKeyColumn("ProblemaSaude");

            //TurmaLetiva
            HasManyToMany(x => x.Turmas).Table("TurmaLetiva")
                                         .ParentKeyColumn("Aluno")
                                         .ChildKeyColumn("Turma");


        }
    }
}
