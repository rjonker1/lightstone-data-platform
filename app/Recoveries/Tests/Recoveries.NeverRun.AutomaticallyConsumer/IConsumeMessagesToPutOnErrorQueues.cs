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
                    (message, info) => new SenderCauseFailureConsumers<SendRequestToDataProviderCommand>(message))
                .Add<GetResponseFromDataProviderCommmand>(
                    (message, info) => new SenderCauseFailureConsumers<GetResponseFromDataProviderCommmand>(message))
                .Add<CreateTransactionCommand>(
                    (message, info) => new SenderCauseFailureConsumers<CreateTransactionCommand>(message))
                .Add<ReceiveEntryPointRequest>(
                    (message, info) => new SenderCauseFailureConsumers<ReceiveEntryPointRequest>(message))
                .Add<ReturnEntryPointResponse>(
                    (message, info) => new SenderCauseFailureConsumers<ReturnEntryPointResponse>(message))
                .Add<RaisingSecurityFlagCommand>(
                    (message, info) => new SenderCauseFailureConsumers<RaisingSecurityFlagCommand>(message))
                .Add<ConfiguringDataProviderCommand>(
                    (message, info) => new SenderCauseFailureConsumers<ConfiguringDataProviderCommand>(message))
                .Add<TransformingDataProviderResponseCommand>(
                    (message, info) => new SenderCauseFailureConsumers<TransformingDataProviderResponseCommand>(message))
                .Add<ErrorInDataProviderCommand>(
                    (message, info) => new SenderCauseFailureConsumers<ErrorInDataProviderCommand>(message))
                .Add<StartingCallCommand>(
                    (message, info) => new SenderCauseFailureConsumers<StartingCallCommand>(message))
                .Add<EndingCallCommand>((message, info) => new SenderCauseFailureConsumers<EndingCallCommand>(message)));

            _bus.Consume(receiverQueue, x => x
                .Add<RequestToDataProvider>(
                    (message, info) => new ReceiverCauseFailureConsumers<RequestToDataProvider>(message))
                .Add<EntryPointReceivedRequest>(
                    (message, info) => new ReceiverCauseFailureConsumers<EntryPointReceivedRequest>(message))
                .Add<ResponseFromDataProvider>(
                    (message, info) => new ReceiverCauseFailureConsumers<ResponseFromDataProvider>(message))
                .Add<EntryPointReturnedResponse>(
                    (message, info) => new ReceiverCauseFailureConsumers<EntryPointReturnedResponse>(message))
                //.Add<BillTransactionMessage>(
                //    (message, info) => new ReceiverConsumers<BillTransactionMessage>(message))
                .Add<SecurityFlagRaised>(
                    (message, info) => new ReceiverCauseFailureConsumers<SecurityFlagRaised>(message))
                .Add<DataProviderCallEnded>(
                    (message, info) => new ReceiverCauseFailureConsumers<DataProviderCallEnded>(message))
                .Add<DataProviderCallStarted>(
                    (message, info) => new ReceiverCauseFailureConsumers<DataProviderCallStarted>(message))
                .Add<DataProviderError>(
                    (message, info) => new ReceiverCauseFailureConsumers<DataProviderError>(message))
                .Add<DataProviderResponseTransformed>(
                    (message, info) => new ReceiverCauseFailureConsumers<DataProviderResponseTransformed>(message))
                .Add<DataProviderConfigured>(
                    (message, info) => new ReceiverCauseFailureConsumers<DataProviderConfigured>(message)));

            _log.DebugFormat("Data Provider Command Processor Service Started");
        }

        public void Stop()
        {
            
        }
    }
}
