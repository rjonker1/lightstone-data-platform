using System.Configuration;
using System.Data.SqlClient;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lim.Schedule.Repositories;

namespace Lim.Schedule.Service.Installers
{
    public class RepositoryInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetLogger<RepositoryInstaller>();
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Repositories");
            container.Register(Component.For<IRepository>().UsingFactoryMethod(() => new Repository(
                new SqlConnection(
                    ConfigurationManager.ConnectionStrings["lim/schedule/database/auto-car-stats"].ToString()))));
        }
    }
}
