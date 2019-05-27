using AutoMapper;
using Red.Application.ViewModel;
using Red.Domain.Entity;

namespace Red.Application.Automapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration Config;

        public static void RegisterMappings()
        {
            Config = new MapperConfiguration(cfg =>
            {
                #region Dados

                cfg.CreateMap<Aluno, AlunoViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<AtividadesPreferidas, AtividadesPreferidasViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Caracteristica, CaracteristicaViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Evangelizador, EvangelizadorViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<ProblemasDeSaude, ProblemasDeSaudeViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Responsavel, ResponsavelViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Status, StatusViewModel>().MaxDepth(2).ReverseMap();
                cfg.CreateMap<Turma, TurmaViewModel>().MaxDepth(2).ReverseMap();

                #endregion
            });
        }
    }
}