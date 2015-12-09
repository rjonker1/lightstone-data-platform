using Api.Domain.Core.Messages;
using Castle.Windsor;
using EasyNetQ;
using EasyNetQ.Topology;
using Workflow.Billing.Messages.Publishable;
using Workflow.Lace.Messages.Commands;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Indicators;
using Workflow.Transactions.Receiver.Service;
using Workflow.Transactions.Sender.Service;

namespace Workflow.DataProvider.Bus.Consumer
{
    public static class ConsumerBuilder
    {
        public static IAdvancedBus BindRecieverQueue(this IAdvancedBus bus, IWindsorContainer container)
        {
            var receiverQueue = bus.QueueDeclare("DataPlatform.DataProvider.Receiver");
            var receiverExchange = bus.ExchangeDeclare("DataPlatform.DataProvider.Receiver", ExchangeType.Fanout);
            bus.Bind(receiverExchange, receiverQueue, string.Empty);
            return bus.AddReceiverConsumers(receiverQueue, container);
        }

        public static IAdvancedBus BindSenderQueue(this IAdvancedBus bus, IWindsorContainer container)
        {
            var senderQueue = bus.QueueDeclare("DataPlatform.DataProvider.Sender");
            var senderExchange = bus.ExchangeDeclare("DataPlatform.DataProvider.Sender", ExchangeType.Fanout);
            bus.Bind(senderExchange, senderQueue, string.Empty);
            return bus.AddSenderConsumers(senderQueue, container);
        }

        public static IAdvancedBus BindApiReceiverQueue(this IAdvancedBus bus, IWindsorContainer container)
        {
            var apiReceiverQueue = bus.QueueDeclare("DataPlatform.Api");
            var apiReceiverExchange = bus.ExchangeDeclare("DataPlatform.Api", ExchangeType.Fanout);
            bus.Bind(apiReceiverExchange, apiReceiverQueue, string.Empty);
            return bus.AddApiReceiverConsumers(apiReceiverQueue, container);
        }

        private static IAdvancedBus AddApiReceiverConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue,
                q => q.Add<RequestMetadataMessage>((message, info) => new ReceiverConsumers<RequestMetadataMessage>(message, container)));
            return bus;
        }

        private static IAdvancedBus AddReceiverConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue, q => q
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
                    (message, info) => new ReceiverConsumers<DataProviderConfigured>(message, container))
                .Add<ExecutionDetailForDataProvider>(
                    (message, info) => new ReceiverConsumers<ExecutionDetailForDataProvider>(message, container))
                .Add<RequestFieldsForDataProvider>(
                    (message, info) => new ReceiverConsumers<RequestFieldsForDataProvider>(message, container)));
            return bus;
        }

        private static IAdvancedBus AddSenderConsumers(this IAdvancedBus bus, IQueue queue, IWindsorContainer container)
        {
            bus.Consume(queue, q => q
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
            return bus;
        }
    }
}
