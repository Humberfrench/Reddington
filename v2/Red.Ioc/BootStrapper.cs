using Red.Repository.Context;
using Red.Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Red.Application.Interfaces;
using Red.Application.Services;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Repository.UnitOfWork;
using Red.Domain.Interfaces.Services;
using Red.Repository;
using Red.Repository.UnitOfWork;
using Red.Services;

namespace Red.Ioc
{
    using SimpleInjector;
    using SimpleInjector.Lifestyles;

    public static class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            #region Infra

            //container.Register<ISecurityContextManager, SecurityContextManager>(Lifestyle.Scoped);
            container.Register<IContextManager, ContextManager>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            #endregion

            #region Suporte - Infra - Security

            container.Register<IAlunoServiceApp, AlunoServiceApp>(Lifestyle.Scoped);
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);

            container.Register<IAtividadePreferidaServiceApp, AtividadePreferidaServiceApp>(Lifestyle.Scoped);
            container.Register<IAtividadesPreferidasService, AtividadesPreferidasService>(Lifestyle.Scoped);
            container.Register<IAtividadesPreferidasRepository, AtividadesPreferidasRepository>(Lifestyle.Scoped);

            container.Register<ICaracteristicaServiceApp, CaracteristicaServiceApp>(Lifestyle.Scoped);
            container.Register<ICaracteristicaService, CaracteristicaService>(Lifestyle.Scoped);
            container.Register<ICaracteristicaRepository, CaracteristicaRepository>(Lifestyle.Scoped);

            container.Register<IEvangelizadorServiceApp, EvangelizadorServiceApp>(Lifestyle.Scoped);
            container.Register<IEvangelizadorService, EvangelizadorService>(Lifestyle.Scoped);
            container.Register<IEvangelizadorRepository, EvangelizadorRepository>(Lifestyle.Scoped);

            container.Register<IProblemaSaudeServiceApp, IProblemaSaudeServiceApp>(Lifestyle.Scoped);
            container.Register<IProblemasDeSaudeService, IProblemasDeSaudeService>(Lifestyle.Scoped);
            container.Register<IProblemasDeSaudeRepository, IProblemasDeSaudeRepository>(Lifestyle.Scoped);

            container.Register<IResponsavelServiceApp, ResponsavelServiceApp>(Lifestyle.Scoped);
            container.Register<IResponsavelService, ResponsavelService>(Lifestyle.Scoped);
            container.Register<IResponsavelRepository, ResponsavelRepository>(Lifestyle.Scoped);

            container.Register<IStatusServiceApp, StatusServiceApp>(Lifestyle.Scoped);
            container.Register<IStatusService, StatusService>(Lifestyle.Scoped);
            container.Register<IStatusRepository, StatusRepository>(Lifestyle.Scoped);

            container.Register<ITurmaServiceApp, TurmaServiceApp>(Lifestyle.Scoped);
            container.Register<ITurmaService, TurmaService>(Lifestyle.Scoped);
            container.Register<ITurmaRepository, TurmaRepository>(Lifestyle.Scoped);

            #endregion

            MyContainer = container;

        }
    }
}
