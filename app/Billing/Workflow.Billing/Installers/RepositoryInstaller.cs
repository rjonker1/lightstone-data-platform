using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using DataPlatform.Shared.Repositories;
using Shared.Configuration;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log.InfoFormat("Installing SQL Server connection");
            var appSettings = new AppSettings();

            container.Register(Component.For(typeof(IRepository<>)).ImplementedBy(typeof(Repository<>)).LifestyleTransient());
        }
    }
}