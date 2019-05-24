using Red.Application;
using Red.Application.Interfaces;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.Domain.Service;
using Red.Repository;
using Red.Repository.UnityOfWork;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Red.Web.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Red.Web.NinjectWebCommon), "Stop")]

namespace Red.Web
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {

            #region Iunit
            kernel.Bind<IUnityOfWork>().To<UnityOfWork>();
            #endregion

            #region Aluno
            kernel.Bind<IAlunoServiceApp>().To<AlunoServiceApp>();
            kernel.Bind<IAlunoService>().To<AlunoService>();
            kernel.Bind<IAlunoRepository>().To<AlunoRepository>();
            #endregion

            #region AtividadePreferida
            kernel.Bind<IAtividadePreferidaServiceApp>().To<AtividadePreferidaServiceApp>();
            kernel.Bind<IAtividadePreferidaService>().To<AtividadePreferidaService>();
            kernel.Bind<IAtividadePreferidaRepository>().To<AtividadePreferidaRepository>();
            #endregion

            #region Caracteristica
            kernel.Bind<ICaracteristicaServiceApp>().To<CaracteristicaServiceApp>();
            kernel.Bind<ICaracteristicaService>().To<CaracteristicaService>();
            kernel.Bind<ICaracteristicaRepository>().To<CaracteristicaRepository>();
            #endregion

            #region Evangelizador
            kernel.Bind<IEvangelizadorServiceApp>().To<EvangelizadorServiceApp>();
            kernel.Bind<IEvangelizadorService>().To<EvangelizadorService>();
            kernel.Bind<IEvangelizadorRepository>().To<EvangelizadorRepository>();
            #endregion

            #region ProblemaSaude
            kernel.Bind<IProblemaSaudeServiceApp>().To<ProblemaSaudeServiceApp>();
            kernel.Bind<IProblemaSaudeService>().To<ProblemaSaudeService>();
            kernel.Bind<IProblemaSaudeRepository>().To<ProblemaSaudeRepository>();
            #endregion

            #region Responsavel
            kernel.Bind<IResponsavelServiceApp>().To<ResponsavelServiceApp>();
            kernel.Bind<IResponsavelService>().To<ResponsavelService>();
            kernel.Bind<IResponsavelRepository>().To<ResponsavelRepository>();
            #endregion

            #region Status
            kernel.Bind<IStatusServiceApp>().To<StatusServiceApp>();
            kernel.Bind<IStatusService>().To<StatusService>();
            kernel.Bind<IStatusRepository>().To<StatusRepository>();
            #endregion

            #region Turma
            kernel.Bind<ITurmaServiceApp>().To<TurmaServiceApp>();
            kernel.Bind<ITurmaService>().To<TurmaService>();
            kernel.Bind<ITurmaRepository>().To<TurmaRepository>();
            #endregion

        }        
    }
}
