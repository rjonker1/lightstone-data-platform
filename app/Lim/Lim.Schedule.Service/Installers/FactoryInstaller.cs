using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Core;
using Lim.Schedule.Core;
using Lim.Schedule.Core.Handlers;
using Lim.Schedule.Service.Resolvers;
using Toolbox.Bmw.Finance;

namespace Lim.Schedule.Service.Installers
{
    public class FactoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<FactoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.Info("Installing Factory Installers");

            container.Register(Component.For<IReadFile>().ImplementedBy<ReadFileFactoryResolver>());
            container.Register(Component.For<IBackupFile>().ImplementedBy<BackupFileResolver>());
            container.Register(Component.For<IPersistObject>().ImplementedBy<PersistFactoryResolver>());
            container.Register(Component.For<IWatchDirectory>().ImplementedBy<DirectoryWatcherResolver>());

            container.Register(
                Component.For<IHandleFetchingFlatFilePullConfiguration>()
                    .ImplementedBy<HandleFetchingFlatFilePullConfiguration>()
                    .LifestyleTransient());

            container.Register(
                Component.For<IHandleExecutingFlatFileConfiguration>().ImplementedBy<HandleExecutingFlatFileConfiguration>().LifestyleTransient());




            _log.Info("Installed Factories");
        }

    }
}
