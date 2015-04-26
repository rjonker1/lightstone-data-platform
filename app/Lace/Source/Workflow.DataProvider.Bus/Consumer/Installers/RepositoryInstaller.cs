using System.Configuration;
using System.Data.SqlClient;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
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
            container.Register(Component.For<ICommandRepository>().UsingFactoryMethod(() => new CommandRepository( new SqlConnection(
                                    ConfigurationManager.ConnectionStrings["workflow/dataprovider/database"]
                                        .ConnectionString), new RepositoryMapper(new MappingDataProviderTypes()))));
            container.Register(
                Component.For<ITransactionRepository>()
                    .UsingFactoryMethod(
                        () =>
                            new TransactionRepository(
                                new SqlConnection(
                                    ConfigurationManager.ConnectionStrings["workflow/transactions/database"]
                                        .ConnectionString), new RepositoryMapper(new MappingTransactionTypes()))));

            container.Register(
                Component.For<IMonitoringRepository>()
                    .UsingFactoryMethod(
                        () =>
                            new MonitoringRepository(
                        new SqlConnection(
                            ConfigurationManager.ConnectionStrings["workflow/monitoring/database"]
                                .ConnectionString), new RepositoryMapper(new MappingForMonitoringTypes()))));

            container.Register(Component.For<IRepositoryMapper>().ImplementedBy<RepositoryMapper>());
            container.Register(Component.For<IRepository>().ImplementedBy<Repository>());
        }
    }
}
