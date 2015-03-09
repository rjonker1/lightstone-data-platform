using DataPlatform.Shared.Identifiers;
using NServiceBus;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Repository;

namespace Workflow.Lace.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseReceivedFromDataProvider>, IHandleMessages<ResponseReturned>
    {
        private readonly IRepository _repository;

        public Response(IRepository repository)
        {
            _repository = repository;
        }


        public void Handle(ResponseReceivedFromDataProvider message)
        {
            var response =
                new DataProviderResponse(new DataProviderResponseIdentifier(message.Id, message.Date,
                    new DataProviderRequestIdentifier(message.RequestId, message.Date,
                        new RequestIdentifier(message.RequestId, null),
                        new DataProviderIdentifier((int) message.DataProvider, message.DataProvider.ToString()),
                        new DataProviderConnectionTypeIdentifier())));

            _repository.Add(response);
        }

        public void Handle(ResponseReturned message)
        {
            var response = new ResponseHeader(new ResponseIdentifier(message.Id, message.RequestId, message.Date));
            _repository.Add(response);
        }
    }
}
