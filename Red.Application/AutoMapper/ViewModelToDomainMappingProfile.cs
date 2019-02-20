
using AutoMapper;
using Red.Application.ViewModel;
using Red.Domain.Entities;

namespace Red.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public override string ProfileName
        {
            get { return "ViewModelToDomainMappings"; }
        }

        protected override void Configure()
        {

            Mapper.CreateMap<AlunoViewModel, Aluno>();
            Mapper.CreateMap<AtividadePreferidaViewModel, AtividadePreferida>();
            Mapper.CreateMap<CaracteristicaViewModel, Caracteristica>();
            Mapper.CreateMap<EvangelizadorViewModel, Evangelizador>();
            Mapper.CreateMap<ProblemaSaudeViewModel, ProblemaSaude>();
            Mapper.CreateMap<ResponsavelViewModel, Responsavel>();
            Mapper.CreateMap<StatusViewModel, Status>();
            Mapper.CreateMap<TurmaViewModel, Turma>();

            //var mapperRedViewModelToDomain = new MapperConfiguration(config =>
            //{
            //    config.CreateMap<AlunoViewModel, Aluno>();
            //    config.CreateMap<AtividadePreferidaViewModel, AtividadePreferida>();
            //    config.CreateMap<CaracteristicaViewModel, Caracteristica>();
            //    config.CreateMap<EvangelizadorViewModel, Evangelizador>();
            //    config.CreateMap<ProblemaSaudeViewModel, ProblemaSaude>();
            //    config.CreateMap<ResponsavelViewModel, Responsavel>();
            //    config.CreateMap<StatusViewModel, Status>();
            //    config.CreateMap<TurmaViewModel, Turma>();
            //});

            //mapperRedViewModelToDomain.CreateMapper();
        }
    }
}