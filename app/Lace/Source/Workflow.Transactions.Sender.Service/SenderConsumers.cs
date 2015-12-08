using System;
using System.Collections.Generic;
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
            Action<IWindsorContainer, IMessage<T>> consumer;
            if (_consumers.TryGetValue(typeof(T), out consumer))
                consumer(container, message);
        }


        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary
            <Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {
                typeof (SendRequestToDataProviderCommand),
                (container, message) => container.Resolve<RequestSenderConsumers>().Consume((IMessage<SendRequestToDataProviderCommand>) message)
            },
            {
                typeof (GetResponseFromDataProviderCommmand),
                (container, message) => container.Resolve<RequestSenderConsumers>().Consume((IMessage<GetResponseFromDataProviderCommmand>) message)
            },
            {
                typeof (CreateTransactionCommand),
                (container, message) => container.Resolve<RequestSenderConsumers>().Consume((IMessage<CreateTransactionCommand>) message)
            },
            {
                typeof (ReceiveEntryPointRequest),
                (container, message) => container.Resolve<RequestSenderConsumers>().Consume((IMessage<ReceiveEntryPointRequest>) message)
            },
            {
                typeof (ReturnEntryPointResponse),
                (container, message) => container.Resolve<RequestSenderConsumers>().Consume((IMessage<ReturnEntryPointResponse>) message)
            },
            {
                typeof (RaisingSecurityFlagCommand),
                (container, message) => container.Resolve<ContextSenderConsumers>().Consume((IMessage<RaisingSecurityFlagCommand>) message)
            },
            {
                typeof (ConfiguringDataProviderCommand),
                (container, message) => container.Resolve<ContextSenderConsumers>().Consume((IMessage<ConfiguringDataProviderCommand>) message)
            },
            {
                typeof (TransformingDataProviderResponseCommand),
                (container, message) =>
                    container.Resolve<ContextSenderConsumers>().Consume((IMessage<TransformingDataProviderResponseCommand>) message)
            },
            {
                typeof (ErrorInDataProviderCommand),
                (container, message) => container.Resolve<ContextSenderConsumers>().Consume((IMessage<ErrorInDataProviderCommand>) message)
            },
            {
                typeof (StartingCallCommand),
                (container, message) => container.Resolve<ContextSenderConsumers>().Consume((IMessage<StartingCallCommand>) message)
            },
            {
                typeof (EndingCallCommand),
                (container, message) => container.Resolve<ContextSenderConsumers>().Consume((IMessage<EndingCallCommand>) message)
            }
        };

    }
}
