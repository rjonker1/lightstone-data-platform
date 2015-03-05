using System;
using NServiceBus;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Request : IHandleMessages<RequestReceived>, IHandleMessages<RequestSentToDataProvider>
    {
        public void Handle(RequestReceived message)
        {
            throw new NotImplementedException();
        }

        public void Handle(RequestSentToDataProvider message)
        {
            throw new NotImplementedException();
        }
    }
}
