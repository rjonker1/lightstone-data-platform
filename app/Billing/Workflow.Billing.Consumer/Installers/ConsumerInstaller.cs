using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Billing.Consumers;

namespace Workflow.Billing.Consumer.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private ILog _log;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log = LogManager.GetLogger(GetType());
            _log.InfoFormat("Installing Billing Consumer");

            container.Register(
                Component.For<BillTransactionConsumer>().ImplementedBy<BillTransactionConsumer>(),
                Component.For<TextMessageConsumer>().ImplementedBy<TextMessageConsumer>(),
            Component.For<EntityConsumer>().ImplementedBy<EntityConsumer>());
        }
    }
}