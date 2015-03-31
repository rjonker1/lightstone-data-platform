using System;
using DataPlatform.Shared.Identifiers;
using NServiceBus;
using Workflow.Billing.Repository;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Request : IHandleMessages<RequestToDataProvider>
    {
        private readonly IRepository _repository;

        public Request()
        {

        }

        public Request(IRepository repository)
        {
            _repository = repository;
        }

        public void Handle(RequestToDataProvider message)
        {
            var request =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Id,
                    message.Date,
                    new RequestIdentifier(message.RequestId, null),
                    new DataProviderIdentifier((int) message.DataProvider, message.DataProvider.ToString()),
                    new ConnectionTypeIdentifier(message.ConnectionType, message.Connection),
                    new ActionIdentifier((int) message.Action, message.Action.ToString()),
                    new StateIdentifier((int) message.State, message.State.ToString())));
            _repository.Add(request);
        }
    }
}
 