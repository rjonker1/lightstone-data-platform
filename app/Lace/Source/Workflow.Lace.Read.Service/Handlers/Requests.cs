using System;
using DataPlatform.Shared.Identifiers;
using NServiceBus;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Request : IHandleMessages<RequestReceived>, IHandleMessages<RequestSentToDataProvider>
    {
        private readonly IRepository _repository;

        public Request(IRepository repository)
        {
            _repository = repository;
        }
        public void Handle(RequestReceived message)
        {
            var request = new RequestHeader(Guid.NewGuid(), message.Date, new RequestIdentifier(message.Id, null));
            _repository.Add(request);
        }

        public void Handle(RequestSentToDataProvider message)
        {
            var request =
                new DataProviderRequest(new DataProviderRequestIdentifier(message.Id, message.Date,
                    new RequestIdentifier(message.RequestId, null),
                    new DataProviderIdentifier((int) message.DataProvider, message.DataProvider.ToString()),
                    new DataProviderConnectionTypeIdentifier(message.ConnectionType, message.Connection)));
            _repository.Add(request);
        }
    }
}
