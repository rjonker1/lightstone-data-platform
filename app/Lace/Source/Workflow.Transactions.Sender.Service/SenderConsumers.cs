using Castle.Windsor;
using EasyNetQ;
using Workflow.Lace.Messages.Commands;
using Workflow.Transactions.Sender.Service.Handlers;

namespace Workflow.Transactions.Sender.Service
{
    public class SenderConsumers<T>
    {
        public SenderConsumers(IMessage<T> message, IWindsorContainer container)
        {
            if (message is IMessage<SendRequestToDataProviderCommand>)
                container.Resolve<RequestSenderConsumers>().Consume((IMessage<SendRequestToDataProviderCommand>)message);
            if (message is IMessage<GetResponseFromDataProviderCommmand>)
                container.Resolve<RequestSenderConsumers>().Consume((IMessage<GetResponseFromDataProviderCommmand>)message);
            if (message is IMessage<CreateTransactionCommand>)
                container.Resolve<RequestSenderConsumers>().Consume((IMessage<CreateTransactionCommand>)message);
            if (message is IMessage<ReceiveEntryPointRequest>)
                container.Resolve<RequestSenderConsumers>().Consume((IMessage<ReceiveEntryPointRequest>)message);
            if (message is IMessage<ReturnEntryPointResponse>)
                container.Resolve<RequestSenderConsumers>().Consume((IMessage<ReturnEntryPointResponse>)message);

            if (message is IMessage<RaisingSecurityFlagCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<RaisingSecurityFlagCommand>)message);
            if (message is IMessage<ConfiguringDataProviderCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<ConfiguringDataProviderCommand>)message);
            if (message is IMessage<TransformingDataProviderResponseCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<TransformingDataProviderResponseCommand>)message);
            if (message is IMessage<ErrorInDataProviderCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<ErrorInDataProviderCommand>)message);
            if (message is IMessage<StartingCallCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<StartingCallCommand>)message);
            if (message is IMessage<EndingCallCommand>)
                container.Resolve<ContextSenderConsumers>().Consume((IMessage<EndingCallCommand>)message);
        }
    }
}
