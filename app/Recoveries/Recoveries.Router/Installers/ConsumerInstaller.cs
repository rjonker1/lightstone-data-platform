using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Recoveries.Router.Consumers;

namespace Recoveries.Router.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<RetryErrorsOnAllQueuesConsumer>().ImplementedBy<RetryErrorsOnAllQueuesConsumer>());
            container.Register(Component.For<RetryErrorsOnAQueuesConsumer>().ImplementedBy<RetryErrorsOnAQueuesConsumer>());
        }
    }
}
