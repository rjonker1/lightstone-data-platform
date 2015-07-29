using System;
using EasyNetQ;
using Workflow.Lace.Messages.Commands;

namespace Recoveries.NeverRun.AutomaticallyConsumer
{
    public class SenderConsumers<T>
    {
        public SenderConsumers(IMessage<T> message)
        {

            if (message is IMessage<SendRequestToDataProviderCommand>)
                new RequestSenderConsumers().Consume((IMessage<SendRequestToDataProviderCommand>) message);
            if (message is IMessage<GetResponseFromDataProviderCommmand>)
                new RequestSenderConsumers().Consume((IMessage<GetResponseFromDataProviderCommmand>) message);
            if (message is IMessage<CreateTransactionCommand>)
                new RequestSenderConsumers().Consume((IMessage<CreateTransactionCommand>) message);
            if (message is IMessage<ReceiveEntryPointRequest>)
                new RequestSenderConsumers().Consume((IMessage<ReceiveEntryPointRequest>) message);
            if (message is IMessage<ReturnEntryPointResponse>)
                new RequestSenderConsumers().Consume((IMessage<ReturnEntryPointResponse>) message);

            if (message is IMessage<RaisingSecurityFlagCommand>)
                new ContextSenderConsumers().Consume((IMessage<RaisingSecurityFlagCommand>) message);
            if (message is IMessage<ConfiguringDataProviderCommand>)
                new ContextSenderConsumers().Consume((IMessage<ConfiguringDataProviderCommand>) message);
            if (message is IMessage<TransformingDataProviderResponseCommand>)
                new ContextSenderConsumers().Consume((IMessage<TransformingDataProviderResponseCommand>) message);
            if (message is IMessage<ErrorInDataProviderCommand>)
                new ContextSenderConsumers().Consume((IMessage<ErrorInDataProviderCommand>) message);
            if (message is IMessage<StartingCallCommand>)
                new ContextSenderConsumers().Consume((IMessage<StartingCallCommand>) message);
            if (message is IMessage<EndingCallCommand>)
                new ContextSenderConsumers().Consume((IMessage<EndingCallCommand>) message);
        }
    }

    public class RequestSenderConsumers
    {
       

        public RequestSenderConsumers()
        {
        }

        public void Consume(IMessage<SendRequestToDataProviderCommand> message)
        {
            throw new Exception("Fail Message for SendRequestToDataProviderCommand");
        }

        public void Consume(IMessage<GetResponseFromDataProviderCommmand> message)
        {
            throw new Exception("Fail Message for GetResponseFromDataProviderCommmand");
        }

        public void Consume(IMessage<CreateTransactionCommand> message)
        {
            throw new Exception("Fail Message for CreateTransactionCommand");
        }

        public void Consume(IMessage<ReceiveEntryPointRequest> message)
        {
            throw new Exception("Fail Message for ReceiveEntryPointRequest");
        }

        public void Consume(IMessage<ReturnEntryPointResponse> message)
        {
            throw new Exception("Fail Message for ReturnEntryPointResponse");
        }
    }

    public class ContextSenderConsumers
    {
        public ContextSenderConsumers()
        {
        }

        public void Consume(IMessage<RaisingSecurityFlagCommand> message)
        {
            throw new Exception("Fail Message for RaisingSecurityFlagCommand");
        }

        public void Consume(IMessage<ConfiguringDataProviderCommand> message)
        {
            throw new Exception("Fail Message for ConfiguringDataProviderCommand");
        }

        public void Consume(IMessage<TransformingDataProviderResponseCommand> message)
        {
            throw new Exception("Fail Message for TransformingDataProviderResponseCommand");
        }

        public void Consume(IMessage<ErrorInDataProviderCommand> message)
        {
            throw new Exception("Fail Message for ErrorInDataProviderCommand");
        }

        public void Consume(IMessage<StartingCallCommand> message)
        {
            throw new Exception("Fail Message for StartingCallCommand");
        }

        public void Consume(IMessage<EndingCallCommand> message)
        {
            throw new Exception("Fail Message for EndingCallCommand");
        }

    }
}
