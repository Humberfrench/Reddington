using AutoMapper;
using Red.Application.ViewModel;
using Red.Domain.Entities;


namespace Red.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Aluno, AlunoViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Aluno, AlunoViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<AtividadePreferida, AtividadePreferidaViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Caracteristica, CaracteristicaViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Evangelizador, EvangelizadorViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<ProblemaSaude, ProblemaSaudeViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Responsavel, ResponsavelViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Status, StatusViewModel>().MaxDepth(2).ReverseMap();
            cfg.CreateMap<Turma, TurmaViewModel>().MaxDepth(2).ReverseMap();

        });

        }

    }
}