using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Common.Logging;
using Workflow.Transactions.Receiver.Service.Handlers;
using Workflow.Transactions.Sender.Service.Handlers;

namespace Workflow.DataProvider.Bus.Consumer.Installers
{
    public class ConsumerInstaller : IWindsorInstaller
    {
        private static readonly ILog Log = LogManager.GetLogger<ConsumerInstaller>();

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            Log.InfoFormat("Installing Consumers");

            container.Register(
                Component.For<ContextSenderConsumers>().ImplementedBy<ContextSenderConsumers>(),
                Component.For<RequestSenderConsumers>().ImplementedBy<RequestSenderConsumers>(),
                Component.For<ContextReceiver>().ImplementedBy<ContextReceiver>(),
                Component.For<RequestsReceiver>().ImplementedBy<RequestsReceiver>(),
                Component.For<ResponsesReceiver>().ImplementedBy<ResponsesReceiver>(),
                Component.For<TransactionReceiver>().ImplementedBy<TransactionReceiver>(),
                Component.For<ApiRequestReceiver>().ImplementedBy<ApiRequestReceiver>(),
                Component.For<IndicatorReceiver>().ImplementedBy<IndicatorReceiver>());
        }
    }
}
