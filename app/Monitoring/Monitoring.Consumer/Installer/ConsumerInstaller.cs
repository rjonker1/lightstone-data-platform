using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Monitoring.Consumer.Lace.Consumers;

namespace Monitoring.Consumer.Installer
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private readonly ILog _log = LogManager.GetCurrentClassLogger();


        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log.InfoFormat("Installing Monitoring Consumer");

            container.Register(
                Component.For<ExternalSourceConsumer>().ImplementedBy<ExternalSourceConsumer>(),
                Component.For<ExternalSourceConfigurationConsumer>()
                    .ImplementedBy<ExternalSourceConfigurationConsumer>(),
                Component.For<ExternalSourceFailedConsumer>().ImplementedBy<ExternalSourceFailedConsumer>(),
                Component.For<ExternalSourceHandledConsumer>().ImplementedBy<ExternalSourceHandledConsumer>(),
                Component.For<ExternalSourceNoResponseReceivedConsumer>()
                    .ImplementedBy<ExternalSourceNoResponseReceivedConsumer>(),
                Component.For<ExternalSourceTransformationConsumer>()
                    .ImplementedBy<ExternalSourceTransformationConsumer>(),
                Component.For<ExternalSourceReceivedResponseConsumer>()
                    .ImplementedBy<ExternalSourceReceivedResponseConsumer>(),
                Component.For<ExternalSourceSentRequestsConsumer>().ImplementedBy<ExternalSourceSentRequestsConsumer>()
                );

        }
    }
}
