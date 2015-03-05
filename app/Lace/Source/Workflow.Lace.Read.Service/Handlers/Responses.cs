using System;
using NServiceBus;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseReceivedFromDataProvider>
    {
        public void Handle(ResponseReceivedFromDataProvider message)
        {
            throw new NotImplementedException();
        }
    }
}
