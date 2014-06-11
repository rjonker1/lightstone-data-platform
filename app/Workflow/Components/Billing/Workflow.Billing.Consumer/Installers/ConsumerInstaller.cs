using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Billing.Consumers;

namespace Workflow.Billing.Consumer.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private readonly ILog log = LogManager.GetCurrentClassLogger();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            log.InfoFormat("Installing BillTransactionConsumer");

            container.Register(
                Component.For<BillTransactionConsumer>().ImplementedBy<BillTransactionConsumer>()
                );
        }
    }
}