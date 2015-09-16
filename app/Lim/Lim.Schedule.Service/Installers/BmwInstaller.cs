using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;
using Toolbox.Bmw.Entities.Factory;
using Toolbox.Bmw.Finance;

namespace Lim.Schedule.Service.Installers
{
    //TODO: This installer is only temporary and needs to be removed
    public class BmwInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<HandlerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing BMW Installers");
            container.Register(Component.For<BmwConfiguration>().UsingFactoryMethod(c => BmwFactoryManager.BuildConfiguration()).LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<ReadFinanceDataFactory>()
                .BasedOn(typeof (IReadFile<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<BackupFinanceDataFactory>()
                .BasedOn(typeof (IBackupFile<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<WatchForFinanceDataFactory>()
               .BasedOn(typeof(IWatchDirectory<>))
               .WithServiceAllInterfaces()
               .LifestyleTransient());

            _log.Info("BMW Installers Installed");
        }
    }
}