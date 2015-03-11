using System;
using DataPlatform.Shared.Identifiers;
using NServiceBus;
using Workflow.Lace.Domain;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Repository;
using DataProviderConnectionTypeIdentifier = Workflow.Lace.Identifiers.DataProviderConnectionTypeIdentifier;
using DataProviderIdentifier = Workflow.Lace.Identifiers.DataProviderIdentifier;
using DataProviderRequestIdentifier = Workflow.Lace.Identifiers.DataProviderRequestIdentifier;
using DataProviderResponseIdentifier = Workflow.Lace.Identifiers.DataProviderResponseIdentifier;
using ResponseIdentifier = Workflow.Lace.Identifiers.ResponseIdentifier;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseReceivedFromDataProvider>, IHandleMessages<ResponseReturned>
    {
        private readonly IRepository _repository;

        public Response()
        {
            
        }

        public Response(IRepository repository)
        {
            _repository = repository;
        }


        public void Handle(ResponseReceivedFromDataProvider message)
        {
            var response =
                new DataProviderResponse(new DataProviderResponseIdentifier(Guid.NewGuid(), message.Id, message.Date,
                    new DataProviderRequestIdentifier(Guid.NewGuid(), message.Id, message.Date,
                        new RequestIdentifier(message.RequestId, null),
                        new DataProviderIdentifier((int) message.DataProvider, message.DataProvider.ToString()),
                        new DataProviderConnectionTypeIdentifier())));

            _repository.Add(response);
        }

        public void Handle(ResponseReturned message)
        {
            var response = new ResponseHeader(new ResponseIdentifier(Guid.NewGuid(),message.Id, message.RequestId, message.Date));
            _repository.Add(response);
        }
    }
}
