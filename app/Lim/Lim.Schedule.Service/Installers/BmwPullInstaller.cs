using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;
using Toolbox.Bmw.Entities.Factory;
using Toolbox.Bmw.Factories;
using Toolbox.Bmw.Notify;

namespace Lim.Schedule.Service.Installers
{
    public class BmwPullInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<HandlerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing BMW Installers");
            container.Register(Component.For<BmwConfiguration>().UsingFactoryMethod(c => BmwFactoryManager.BuildConfiguration()).LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<ReadFinanceDataFileFactory>()
                .BasedOn(typeof (IRead<,>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<BackupFinanceDataFileFactory>()
                .BasedOn(typeof (IBackup<>))
                .WithServiceAllInterfaces()
                .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<FailFinanceDataFileFactory>()
               .BasedOn(typeof(IFail<>))
               .WithServiceAllInterfaces()
               .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<WatchForFinanceDataFileFactory>()
               .BasedOn(typeof(IWatch<>))
               .WithServiceAllInterfaces()
               .LifestyleTransient());

            container.Register(Classes.FromAssemblyContaining<FileNotificationFactory>()
              .BasedOn(typeof(INotify<>))
              .WithServiceAllInterfaces()
              .LifestyleTransient());

            _log.Info("BMW Installers Installed");
        }
    }
}