using System;
using EasyNetQ;
using Workflow.Lace.Messages.Events;

namespace Recoveries.NeverRun.AutomaticallyConsumer
{
    public class ReceiverConsumers<T>
    {
        public ReceiverConsumers(IMessage<T> message)
        {
            if (message is IMessage<RequestToDataProvider>)
                new RequestsReceiver().Consume((IMessage<RequestToDataProvider>)message);
            if (message is IMessage<EntryPointReceivedRequest>)
                new RequestsReceiver().Consume((IMessage<EntryPointReceivedRequest>)message);

            if (message is IMessage<ResponseFromDataProvider>)
                new ResponsesReceiver().Consume((IMessage<ResponseFromDataProvider>)message);
            if (message is IMessage<EntryPointReturnedResponse>)
                new ResponsesReceiver().Consume((IMessage<EntryPointReturnedResponse>)message);

            if (message is IMessage<SecurityFlagRaised>)
                new ContextReceiver().Consume((IMessage<SecurityFlagRaised>)message);
            if (message is IMessage<DataProviderConfigured>)
                new ContextReceiver().Consume((IMessage<DataProviderConfigured>)message);
            if (message is IMessage<DataProviderCallEnded>)
                new ContextReceiver().Consume((IMessage<DataProviderCallEnded>)message);
            if (message is IMessage<DataProviderCallStarted>)
                new ContextReceiver().Consume((IMessage<DataProviderCallStarted>)message);
            if (message is IMessage<DataProviderError>)
                new ContextReceiver().Consume((IMessage<DataProviderError>)message);
            if (message is IMessage<DataProviderResponseTransformed>)
                new ContextReceiver().Consume((IMessage<DataProviderResponseTransformed>)message);

            //if (message is IMessage<BillTransactionMessage>)
            //    container.Resolve<Handlers.TransactionReceiver>().Consume((IMessage<BillTransactionMessage>)message);
        }
    }

    public class RequestsReceiver
    { 
        public RequestsReceiver()
        {
        }

        public void Consume(IMessage<RequestToDataProvider> message)
        {
            throw new Exception("Message failed for RequestToDataProvider");
        }

        public void Consume(IMessage<EntryPointReceivedRequest> message)
        {
            throw new Exception("Message failed for EntryPointReceivedRequest");
        }
    }

    public class ResponsesReceiver
    {
        public ResponsesReceiver()
        {
        }

        public void Consume(IMessage<ResponseFromDataProvider> message)
        {
            throw new Exception("Message failed for ResponseFromDataProvider");
        }

        public void Consume(IMessage<EntryPointReturnedResponse> message)
        {
            throw new Exception("Message failed for EntryPointReturnedResponse");
        }
    }

    public class ContextReceiver
    {
        public void Consume(IMessage<SecurityFlagRaised> message)
        {

        }

        public void Consume(IMessage<DataProviderConfigured> message)
        {

        }

        public void Consume(IMessage<DataProviderCallEnded> message)
        {

        }

        public void Consume(IMessage<DataProviderCallStarted> message)
        {

        }

        public void Consume(IMessage<DataProviderError> message)
        {

        }

        public void Consume(IMessage<DataProviderResponseTransformed> message)
        {

        }
    }
}
