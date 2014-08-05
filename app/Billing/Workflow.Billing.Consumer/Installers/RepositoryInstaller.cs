using System.Data;
using System.Data.SqlClient;
using BuildingBlocks.Configuration;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Billing.Repository;

namespace Workflow.Billing.Consumer.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log.InfoFormat("Installing SQL Server connection");
            var appSettings = new AppSettings();

            container.Register(
                Component.For<IDbConnection>()
                    .UsingFactoryMethod(() => new SqlConnection(appSettings.ConnectionStrings.Get("workflow/billing/database", () => string.Empty))));

            container.Register(Component.For<IRepository>().ImplementedBy<Repository.Repository>());
        }
    }
}