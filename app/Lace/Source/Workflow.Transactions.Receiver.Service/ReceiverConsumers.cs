using Api.Domain.Core.Messages;
using Castle.Windsor;
using EasyNetQ;
using Workflow.Billing.Messages.Publishable;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Indicators;
using Workflow.Transactions.Receiver.Service.Handlers;

namespace Workflow.Transactions.Receiver.Service
{
    public class ReceiverConsumers<T>
    {
        public ReceiverConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<RequestToDataProvider>)
                container.Resolve<RequestsReceiver>().Consume((IMessage<RequestToDataProvider>) message);
            if (message is IMessage<EntryPointReceivedRequest>)
                container.Resolve<RequestsReceiver>().Consume((IMessage<EntryPointReceivedRequest>) message);

            if (message is IMessage<ResponseFromDataProvider>)
                container.Resolve<ResponsesReceiver>().Consume((IMessage<ResponseFromDataProvider>)message);
            if (message is IMessage<EntryPointReturnedResponse>)
                container.Resolve<ResponsesReceiver>().Consume((IMessage<EntryPointReturnedResponse>)message);

            if (message is IMessage<SecurityFlagRaised>)
                container.Resolve<ContextReceiver>().Consume((IMessage<SecurityFlagRaised>)message);
            if (message is IMessage<DataProviderConfigured>)
                container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderConfigured>)message);
            if (message is IMessage<DataProviderCallEnded>)
                container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderCallEnded>)message);
            if (message is IMessage<DataProviderCallStarted>)
                container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderCallStarted>)message);
            if (message is IMessage<DataProviderError>)
                container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderError>)message);
            if (message is IMessage<DataProviderResponseTransformed>)
                container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderResponseTransformed>)message);

            if (message is IMessage<BillTransactionMessage>)
                container.Resolve<TransactionReceiver>().Consume((IMessage<BillTransactionMessage>)message);

            if (message is IMessage<RequestMetadataMessage>)
                container.Resolve<ApiRequestReceiver>().Consume((IMessage<RequestMetadataMessage>)message);

            if(message is IMessage<ExecutionDetailForDataProvider>)
                container.Resolve<IndicatorReceiver>().Consume((IMessage<ExecutionDetailForDataProvider>)message);
            if (message is IMessage<RequestFieldsForDataProvider>)
                container.Resolve<IndicatorReceiver>().Consume((IMessage<RequestFieldsForDataProvider>)message);
        }
    }
}
