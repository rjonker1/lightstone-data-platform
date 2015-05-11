using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Lace.Caching.Manager.Service.Consumers;

namespace Lace.Caching.Manager.Service.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private ILog _log;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log = LogManager.GetLogger(GetType());
            _log.InfoFormat("Installing Consumers");
            container.Register(
                Component.For<CacheConsumer>().ImplementedBy<CacheConsumer>());
        }
    }
}
