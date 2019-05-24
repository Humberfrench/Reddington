using AutoMapper;
using Red.Application.ViewModel;
using Red.Domain.Entities;

namespace Red.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {


        protected override void Configure()
        {
            Mapper.CreateMap<Aluno, AlunoViewModel>();
            Mapper.CreateMap<AtividadePreferida, AtividadePreferidaViewModel>();
            Mapper.CreateMap<Caracteristica, CaracteristicaViewModel>();
            Mapper.CreateMap<Evangelizador, EvangelizadorViewModel>();
            Mapper.CreateMap<ProblemaSaude, ProblemaSaudeViewModel>();
            Mapper.CreateMap<Responsavel, ResponsavelViewModel>();
            Mapper.CreateMap<Status, StatusViewModel>();
            Mapper.CreateMap<Turma, TurmaViewModel>();

            //var mapperRedDomainToViewModel = new MapperConfiguration(config =>
            //{
            //    config.CreateMap<Aluno, AlunoViewModel>();
            //    config.CreateMap<AtividadePreferida, AtividadePreferidaViewModel>();
            //    config.CreateMap<Caracteristica, CaracteristicaViewModel>();
            //    config.CreateMap<Evangelizador, EvangelizadorViewModel>();
            //    config.CreateMap<ProblemaSaude, ProblemaSaudeViewModel>();
            //    config.CreateMap<Responsavel, ResponsavelViewModel>();
            //    config.CreateMap<Status, StatusViewModel>();
            //    config.CreateMap<Turma, TurmaViewModel>();
            //});

            //mapperRedDomainToViewModel.CreateMapper();

        }
    }
}