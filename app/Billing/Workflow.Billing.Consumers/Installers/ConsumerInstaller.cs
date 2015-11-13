using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Billing.Consumers.ConsumerTypes;

namespace Workflow.Billing.Consumers.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private ILog _log;

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            _log = LogManager.GetLogger(GetType());
            _log.InfoFormat("Installing Billing Consumer");

            container.Register(
                Component.For<InvoiceTransactionConsumer>().ImplementedBy<InvoiceTransactionConsumer>(),
                Component.For<UserConsumer>().ImplementedBy<UserConsumer>(),
                Component.For<CustomerConsumer>().ImplementedBy<CustomerConsumer>(),
                Component.For<ClientConsumer>().ImplementedBy<ClientConsumer>(),
                Component.For<PackageConsumer>().ImplementedBy<PackageConsumer>(),
                Component.For<BillRunConsumer>().ImplementedBy<BillRunConsumer>(),
                Component.For<ContractConsumer>().ImplementedBy<ContractConsumer>(),
                Component.For<BillCacheConsumer>().ImplementedBy<BillCacheConsumer>(),
                Component.For<TransactionRequestConsumer>().ImplementedBy<TransactionRequestConsumer>(),
                Component.For<TransactionRequestCleanupConsumer>().ImplementedBy<TransactionRequestCleanupConsumer>(),
                Component.For(typeof(TransactionConsumer<>)).ImplementedBy(typeof(TransactionConsumer<>)));
        }
    }
}