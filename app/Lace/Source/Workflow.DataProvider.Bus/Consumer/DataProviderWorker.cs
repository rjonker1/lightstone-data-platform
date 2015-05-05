using Castle.Windsor;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.Billing.Messages.Publishable;
using Workflow.DataProvider.Bus.Consumer.Installers;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Events;
using Workflow.Transactions.Receiver.Service;
using Workflow.Transactions.Sender.Service;

namespace Workflow.DataProvider.Bus.Consumer
{
    public class DataProviderWorker : IDataProviderWorker
    {
        private readonly ILog _log = LogManager.GetLogger<DataProviderWorker>();
        private IAdvancedBus _bus;

        public void Start()
        {
            _log.DebugFormat("Data Provider Command Processor Service being fired up...");

            var container = new WindsorContainer().Install(
                new WindsorInstaller(),
                new RepositoryInstaller(),
                new ConsumerInstaller(),
                new BusInstaller());

            _bus = container.Resolve<IAdvancedBus>();
            var senderQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Sender");
            var senderExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Sender", ExchangeType.Fanout);
            _bus.Bind(senderExchange, senderQueue, string.Empty);

            var receiverQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Receiver");
            var receiverExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Receiver", ExchangeType.Fanout);
            _bus.Bind(receiverExchange, receiverQueue, string.Empty);

            _bus.Consume(senderQueue, x => x
                .Add<SendRequestToDataProviderCommand>(
                    (message, info) => new SenderConsumers<SendRequestToDataProviderCommand>(message, container))
                .Add<GetResponseFromDataProviderCommmand>(
                    (message, info) => new SenderConsumers<GetResponseFromDataProviderCommmand>(message, container))
                .Add<CreateTransactionCommand>(
                    (message, info) => new SenderConsumers<CreateTransactionCommand>(message, container))
                .Add<ReceiveEntryPointRequest>(
                    (message, info) => new SenderConsumers<ReceiveEntryPointRequest>(message, container))
                .Add<ReturnEntryPointResponse>(
                    (message, info) => new SenderConsumers<ReturnEntryPointResponse>(message, container))
                .Add<RaisingSecurityFlagCommand>(
                    (message, info) => new SenderConsumers<RaisingSecurityFlagCommand>(message, container))
                .Add<ConfiguringDataProviderCommand>(
                    (message, info) => new SenderConsumers<ConfiguringDataProviderCommand>(message, container))
                .Add<TransformingDataProviderResponseCommand>(
                    (message, info) => new SenderConsumers<TransformingDataProviderResponseCommand>(message, container))
                .Add<ErrorInDataProviderCommand>(
                    (message, info) => new SenderConsumers<ErrorInDataProviderCommand>(message, container))
                .Add<StartingCallCommand>(
                    (message, info) => new SenderConsumers<StartingCallCommand>(message, container))
                .Add<EndingCallCommand>((message, info) => new SenderConsumers<EndingCallCommand>(message, container)));

            _bus.Consume(receiverQueue, x => x
                .Add<RequestToDataProvider>(
                    (message, info) => new ReceiverConsumers<RequestToDataProvider>(message, container))
                .Add<EntryPointReceivedRequest>(
                    (message, info) => new ReceiverConsumers<EntryPointReceivedRequest>(message, container))
                .Add<ResponseFromDataProvider>(
                    (message, info) => new ReceiverConsumers<ResponseFromDataProvider>(message, container))
                .Add<EntryPointReturnedResponse>(
                    (message, info) => new ReceiverConsumers<EntryPointReturnedResponse>(message, container))
                .Add<BillTransactionMessage>(
                    (message, info) => new ReceiverConsumers<BillTransactionMessage>(message, container))
                .Add<SecurityFlagRaised>(
                    (message, info) => new ReceiverConsumers<SecurityFlagRaised>(message, container))
                .Add<DataProviderCallEnded>(
                    (message, info) => new ReceiverConsumers<DataProviderCallEnded>(message, container))
                .Add<DataProviderCallStarted>(
                    (message, info) => new ReceiverConsumers<DataProviderCallStarted>(message, container))
                .Add<DataProviderError>(
                    (message, info) => new ReceiverConsumers<DataProviderError>(message, container))
                .Add<DataProviderResponseTransformed>(
                    (message, info) => new ReceiverConsumers<DataProviderResponseTransformed>(message, container))
                .Add<DataProviderConfigured>(
                    (message, info) => new ReceiverConsumers<DataProviderConfigured>(message, container)));

            _log.DebugFormat("Data Provider Command Processor Service Started");
        }

        public void Stop()
        {
            if (_bus != null)
            {
                _bus.Dispose();
            }

            _log.DebugFormat("Stopped Data Provider Command Processor Service");
        }
    }
}
