using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;
using Lim.Schedule.Service.Resolvers;
using Toolbox.Emailing.Domain;

namespace Lim.Schedule.Service.Installers
{
    public class FactoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<FactoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing Factory Installers");

            container.Register(Component.For<IRead>().ImplementedBy<ReadFactoryResolver>());
            container.Register(Component.For<IBackup>().ImplementedBy<BackupFactoryResolver>());
            container.Register(Component.For<IFail>().ImplementedBy<FailFactoryResolver>());
            container.Register(Component.For<IPersist>().ImplementedBy<PersistFactoryResolver>());
            container.Register(Component.For<IWatch>().ImplementedBy<WatcherResolver>());
            container.Register(Component.For<IFetch>().ImplementedBy<FetchFactoryResolver>());
            container.Register(Component.For<IInitialize>().ImplementedBy<InitializeResolver>());
            container.Register(Component.For<IPull>().ImplementedBy<PullResolver>());
            container.Register(Component.For<IPush>().ImplementedBy<PushResolver>());
            container.Register(Component.For<IAudit>().ImplementedBy<AuditorResolver>());
            container.Register(Component.For<INotify>().ImplementedBy<NotifyFactoryResolver>());
            container.Register(Component.For<IBuildMessage>().ImplementedBy<MessageBuilderResolver>());
            container.Register(Component.For<IDispatchMail>().ImplementedBy<DispatchMailResolver>());

            _log.Info("Installed Factories");
        }
    }
}