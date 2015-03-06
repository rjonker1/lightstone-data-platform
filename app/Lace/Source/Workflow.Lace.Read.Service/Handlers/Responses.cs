using System;
using NServiceBus;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseReceivedFromDataProvider>, IHandleMessages<ResponseReturned>
    {
        public void Handle(ResponseReceivedFromDataProvider message)
        {
            throw new NotImplementedException();
        }

        public void Handle(ResponseReturned message)
        {
            throw new NotImplementedException();
        }
    }
}
