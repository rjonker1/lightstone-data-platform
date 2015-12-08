using System;
using System.Collections.Generic;
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
           Action<IWindsorContainer,IMessage<T>> consumer;
           if (_consumers.TryGetValue(typeof(T), out consumer)) 
               consumer(container, message);
        }

        private readonly Dictionary<Type, Action<IWindsorContainer, IMessage<T>>> _consumers = new Dictionary
            <Type, Action<IWindsorContainer, IMessage<T>>>
        {
            {
                typeof (RequestToDataProvider),
                (container, message) => container.Resolve<RequestsReceiver>().Consume((IMessage<RequestToDataProvider>) message)
            },
            {
                typeof (EntryPointReceivedRequest),
                (container, message) => container.Resolve<RequestsReceiver>().Consume((IMessage<EntryPointReceivedRequest>) message)
            },
            {
                typeof (ResponseFromDataProvider),
                (container, message) => container.Resolve<ResponsesReceiver>().Consume((IMessage<ResponseFromDataProvider>) message)
            },
            {
                typeof (EntryPointReturnedResponse),
                (container, message) => container.Resolve<ResponsesReceiver>().Consume((IMessage<EntryPointReturnedResponse>) message)
            },
            {
                typeof (SecurityFlagRaised), (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<SecurityFlagRaised>) message)
            },
            {
                typeof (DataProviderConfigured),
                (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderConfigured>) message)
            },
            {
                typeof (DataProviderCallEnded),
                (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderCallEnded>) message)
            },
            {
                typeof (DataProviderCallStarted),
                (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderCallStarted>) message)
            },
            {typeof (DataProviderError), (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderError>) message)},
            {
                typeof (DataProviderResponseTransformed),
                (container, message) => container.Resolve<ContextReceiver>().Consume((IMessage<DataProviderResponseTransformed>) message)
            },
            {
                typeof (BillTransactionMessage),
                (container, message) => container.Resolve<TransactionReceiver>().Consume((IMessage<BillTransactionMessage>) message)
            }
            ,
            {
                typeof (RequestMetadataMessage),
                (container, message) => container.Resolve<ApiRequestReceiver>().Consume((IMessage<RequestMetadataMessage>) message)
            },
            {
                typeof (ExecutionDetailForDataProvider),
                (container, message) => container.Resolve<IndicatorReceiver>().Consume((IMessage<ExecutionDetailForDataProvider>) message)
            },
            {
                typeof (RequestFieldsForDataProvider),
                (container, message) => container.Resolve<IndicatorReceiver>().Consume((IMessage<RequestFieldsForDataProvider>) message)
            }
        };
    }
}