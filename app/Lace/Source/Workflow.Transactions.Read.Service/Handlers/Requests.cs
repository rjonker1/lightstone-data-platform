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
                    message.Date, new RequestIdentifier(message.Id, null),
                    message.DataProvider, message.Connection,
                    new ActionIdentifier((int) message.DataProvider.Action, message.DataProvider.Action.ToString()),
                    new StateIdentifier((int) message.DataProvider.State, message.DataProvider.State.ToString())));
            _repository.Add(request);
        }
    }
}
 