using Red.Application;
using Red.Application.Interfaces;
using Red.Domain.Interfaces.Repository;
using Red.Domain.Interfaces.Service;
using Red.Domain.Service;
using Red.Repository;
using Red.Repository.UnityOfWork;
using SimpleInjector;

namespace Red.Ioc
{
    public class BootStrapper
    {
        public static Container MyContainer { get; set; }

        public static void Register(Container container)
        {
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            MyContainer = container;

            #region Dev
            container.Register<IUnityOfWork, UnityOfWork>(Lifestyle.Scoped);
            #endregion

            #region Aluno
            container.Register<IAlunoServiceApp, AlunoServiceApp>(Lifestyle.Scoped);
            container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);
            container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);
            #endregion

            #region AtividadePreferida
            container.Register<IAtividadePreferidaServiceApp, AtividadePreferidaServiceApp>(Lifestyle.Scoped);
            container.Register<IAtividadePreferidaService, AtividadePreferidaService>(Lifestyle.Scoped);
            container.Register<IAtividadePreferidaRepository, AtividadePreferidaRepository>(Lifestyle.Scoped);
            #endregion

            #region Caracteristica
            container.Register<ICaracteristicaServiceApp, CaracteristicaServiceApp>(Lifestyle.Scoped);
            container.Register<ICaracteristicaService, CaracteristicaService>(Lifestyle.Scoped);
            container.Register<ICaracteristicaRepository, CaracteristicaRepository>(Lifestyle.Scoped);
            #endregion

            #region Evangelizador
            container.Register<IEvangelizadorServiceApp, EvangelizadorServiceApp>(Lifestyle.Scoped);
            container.Register<IEvangelizadorService, EvangelizadorService>(Lifestyle.Scoped);
            container.Register<IEvangelizadorRepository, EvangelizadorRepository>(Lifestyle.Scoped);
            #endregion

            #region ProblemaSaude
            container.Register<IProblemaSaudeServiceApp, ProblemaSaudeServiceApp>(Lifestyle.Scoped);
            container.Register<IProblemaSaudeService, ProblemaSaudeService>(Lifestyle.Scoped);
            container.Register<IProblemaSaudeRepository, ProblemaSaudeRepository>(Lifestyle.Scoped);
            #endregion

            #region Responsavel
            container.Register<IResponsavelServiceApp, ResponsavelServiceApp>(Lifestyle.Scoped);
            container.Register<IResponsavelService, ResponsavelService>(Lifestyle.Scoped);
            container.Register<IResponsavelRepository, ResponsavelRepository>(Lifestyle.Scoped);
            #endregion

            #region Status
            container.Register<IStatusServiceApp, StatusServiceApp>(Lifestyle.Scoped);
            container.Register<IStatusService, StatusService>(Lifestyle.Scoped);
            container.Register<IStatusRepository, StatusRepository>(Lifestyle.Scoped);
            #endregion

            #region Turma
            container.Register<ITurmaServiceApp, TurmaServiceApp>(Lifestyle.Scoped);
            container.Register<ITurmaService, TurmaService>(Lifestyle.Scoped);
            container.Register<ITurmaRepository, TurmaRepository>(Lifestyle.Scoped);
            #endregion



            //// APP
            //container.Register<IAlunoAppService, AlunoAppService>(Lifestyle.Scoped);

            //// Domain
            //container.Register<IAlunoService, AlunoService>(Lifestyle.Scoped);

            //// Infra Dados Repos
            //container.Register<IAlunoRepository, AlunoRepository>(Lifestyle.Scoped);

            //// Infra Dados
            //container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            //container.Register<AlunosContext>(Lifestyle.Scoped);

            //// Handlers
            //container.Register<IHandler<DomainNotification>, DomainNotificationHandler>(Lifestyle.Scoped);
            //container.Register<IHandler<AlunoCadastradoEvent>, AlunoCadastradoHandler>(Lifestyle.Scoped);

            //// Infra Core
            //container.Register<IEnvioEmail, EnvioEmail>(Lifestyle.Singleton);

            //// Identity
            //container.Register<ApplicationDbContext>(Lifestyle.Scoped);
            //container.Register<IUserStore<ApplicationUser>>(() => new UserStore<ApplicationUser>(new ApplicationDbContext()), Lifestyle.Scoped);
            //container.Register<IRoleStore<IdentityRole, string>>(() => new RoleStore<IdentityRole>(), Lifestyle.Scoped);
            //container.Register<ApplicationRoleManager>(Lifestyle.Scoped);
            //container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            //container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
        }

    }
}
