using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using EventTracking.Domain.Persistence;
using EventTracking.Domain.Persistence.EventStore;

namespace Monitoring.Consumer.Installer
{
    public class PersistenceInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Persistence consumer for events");

            container.Register(Component.For<IPersistEvent>().ImplementedBy<PersistEvent>());
        }
    }
}
