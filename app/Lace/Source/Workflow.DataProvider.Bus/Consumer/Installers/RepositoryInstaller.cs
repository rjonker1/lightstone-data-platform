using System.Configuration;
using System.Data.SqlClient;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lace.Domain.DataProviders.Core.Configuration;
using Monitoring.Domain.Mappers;
using Monitoring.Domain.Repository;
using Shared.BuildingBlocks.AdoNet.Repository;
using Workflow.Billing.Messages;
using Workflow.Lace.Mappers;
using Workflow.Lace.Persistence;

namespace Workflow.DataProvider.Bus.Consumer.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Repositories");
            container.Register(
                Component.For<IEventRepository>().UsingFactoryMethod(() => new EventRepository(new RepositoryMapper(new MappingDataProviderTypes()))));
            container.Register(
                Component.For<ITransactionRepository>()
                    .UsingFactoryMethod(
                        () =>
                            new TransactionRepository(new SqlConnection(WorkflowConfiguration.TransactionDatabase), new RepositoryMapper(new MappingTransactionTypes()))));

            container.Register(
                Component.For<IMonitoringRepository>()
                    .UsingFactoryMethod(
                        () =>
                            new MonitoringRepository(new RepositoryMapper(new MappingForMonitoringTypes()))));

            container.Register(Component.For<IRepositoryMapper>().ImplementedBy<RepositoryMapper>());
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());
        }
    }
}
