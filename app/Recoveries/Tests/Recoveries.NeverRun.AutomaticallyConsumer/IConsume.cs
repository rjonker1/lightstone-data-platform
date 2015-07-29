using System;
using Common.Logging;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.BuildingBlocks;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Reader;

namespace Recoveries.NeverRun.AutomaticallyConsumer
{
    public interface IConsumeMessagesToPutOnErrorQueues
    {
        void Start();
        void Stop();
    }

    public class CauseErrorQueueConsumer : IConsumeMessagesToPutOnErrorQueues
    {
        private readonly ILog _log = LogManager.GetLogger<CauseErrorQueueConsumer>();
        private IAdvancedBus _bus;

        public void Start()
        {
            _bus = BusFactory.CreateAdvancedBus(ConfigurationReader.WorkflowSender);
            var senderQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Sender");
            var senderExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Sender", ExchangeType.Fanout);
            _bus.Bind(senderExchange, senderQueue, string.Empty);

            var receiverQueue = _bus.QueueDeclare("DataPlatform.DataProvider.Receiver");
            var receiverExchange = _bus.ExchangeDeclare("DataPlatform.DataProvider.Receiver", ExchangeType.Fanout);
            _bus.Bind(receiverExchange, receiverQueue, string.Empty);

            _bus.Consume(senderQueue, x => x
                .Add<SendRequestToDataProviderCommand>(
                    (message, info) => new SenderConsumers<SendRequestToDataProviderCommand>(message))
                .Add<GetResponseFromDataProviderCommmand>(
                    (message, info) => new SenderConsumers<GetResponseFromDataProviderCommmand>(message))
                .Add<CreateTransactionCommand>(
                    (message, info) => new SenderConsumers<CreateTransactionCommand>(message))
                .Add<ReceiveEntryPointRequest>(
                    (message, info) => new SenderConsumers<ReceiveEntryPointRequest>(message))
                .Add<ReturnEntryPointResponse>(
                    (message, info) => new SenderConsumers<ReturnEntryPointResponse>(message))
                .Add<RaisingSecurityFlagCommand>(
                    (message, info) => new SenderConsumers<RaisingSecurityFlagCommand>(message))
                .Add<ConfiguringDataProviderCommand>(
                    (message, info) => new SenderConsumers<ConfiguringDataProviderCommand>(message))
                .Add<TransformingDataProviderResponseCommand>(
                    (message, info) => new SenderConsumers<TransformingDataProviderResponseCommand>(message))
                .Add<ErrorInDataProviderCommand>(
                    (message, info) => new SenderConsumers<ErrorInDataProviderCommand>(message))
                .Add<StartingCallCommand>(
                    (message, info) => new SenderConsumers<StartingCallCommand>(message))
                .Add<EndingCallCommand>((message, info) => new SenderConsumers<EndingCallCommand>(message)));

            _bus.Consume(receiverQueue, x => x
                .Add<RequestToDataProvider>(
                    (message, info) => new ReceiverConsumers<RequestToDataProvider>(message))
                .Add<EntryPointReceivedRequest>(
                    (message, info) => new ReceiverConsumers<EntryPointReceivedRequest>(message))
                .Add<ResponseFromDataProvider>(
                    (message, info) => new ReceiverConsumers<ResponseFromDataProvider>(message))
                .Add<EntryPointReturnedResponse>(
                    (message, info) => new ReceiverConsumers<EntryPointReturnedResponse>(message))
                //.Add<BillTransactionMessage>(
                //    (message, info) => new ReceiverConsumers<BillTransactionMessage>(message))
                .Add<SecurityFlagRaised>(
                    (message, info) => new ReceiverConsumers<SecurityFlagRaised>(message))
                .Add<DataProviderCallEnded>(
                    (message, info) => new ReceiverConsumers<DataProviderCallEnded>(message))
                .Add<DataProviderCallStarted>(
                    (message, info) => new ReceiverConsumers<DataProviderCallStarted>(message))
                .Add<DataProviderError>(
                    (message, info) => new ReceiverConsumers<DataProviderError>(message))
                .Add<DataProviderResponseTransformed>(
                    (message, info) => new ReceiverConsumers<DataProviderResponseTransformed>(message))
                .Add<DataProviderConfigured>(
                    (message, info) => new ReceiverConsumers<DataProviderConfigured>(message)));

            _log.DebugFormat("Data Provider Command Processor Service Started");
        }

        public void Stop()
        {
            
        }
    }
}
