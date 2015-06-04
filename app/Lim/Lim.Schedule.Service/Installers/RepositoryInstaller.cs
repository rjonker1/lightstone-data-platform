using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Domain.Entities.Repository;
using NHibernate;

namespace Lim.Schedule.Service.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Repositories");

            container.Register(Component.For<IAmRepository>().UsingFactoryMethod(() => new LimRepository(container.Resolve<ISession>())));

            _log.InfoFormat("Repositories Installed");
        }
    }
}