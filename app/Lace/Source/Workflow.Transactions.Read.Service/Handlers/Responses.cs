using System;
using DataPlatform.Shared.Identifiers;
using NServiceBus;
using Workflow.Billing.Repository;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseFromDataProvider>
    {
        private readonly IRepository _repository;

        public Response()
        {
            
        }

        public Response(IRepository repository)
        {
            _repository = repository;
        }


        public void Handle(ResponseFromDataProvider message)
        {
            var response =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Id,
                    message.Date, new RequestIdentifier(message.Id, null),
                    new DataProviderIdentifier((int) message.DataProvider, message.DataProvider.ToString())
                    , new ConnectionTypeIdentifier(message.ConnectionType, message.Connection),
                    new ActionIdentifier((int) message.Action, message.Action.ToString()),
                    new StateIdentifier((int) message.State, message.State.ToString())));
            _repository.Add(response);
        }
    }
}
