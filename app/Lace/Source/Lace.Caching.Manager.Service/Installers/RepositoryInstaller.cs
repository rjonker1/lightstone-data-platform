using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.CrossCutting.Infrastructure.Orm.Connections;
using Lace.Domain.Core.Contracts.Caching;

namespace Lace.Caching.Manager.Service.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Repositories");
            container.Register(Component.For<ICacheRepository>().UsingFactoryMethod(() => new CacheDataRepository(
                ConnectionFactory.ForAutoCarStatsDatabase())));
        }
    }
}
