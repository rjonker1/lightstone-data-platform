using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using Lace.Shared.Extensions;
using Monitoring.Domain;
using Monitoring.Domain.Identifiers;
using Monitoring.Domain.Repository;
using NServiceBus;
using Workflow.Billing.Messages;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Request : IHandleMessages<RequestToDataProvider>, IHandleMessages<EntryPointReceivedRequest>
    {
        private readonly ITransactionRepository _transaction;
        private readonly IMonitoringRepository _monitoring;

        public Request()
        {

        }

        public Request(ITransactionRepository transaction, IMonitoringRepository monitoring)
        {
            _transaction = transaction;
            _monitoring = monitoring;
        }

        public void Handle(RequestToDataProvider message)
        {
            var request =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Id,
                    message.Date, new RequestIdentifier(message.Id, null),
                    message.DataProvider, message.Connection,
                    new ActionIdentifier((int) message.DataProvider.Action, message.DataProvider.Action.ToString()),
                    new StateIdentifier((int) message.DataProvider.State, message.DataProvider.State.ToString())));
            _transaction.Add(request);
        }

        public void Handle(EntryPointReceivedRequest message)
        {
            var request =
                new MonitoringDataProviderTransaction(new MonitoringDataProviderIdentifier(Guid.NewGuid(), message.Date,
                    new SearchIdentifier(message.Request.Type, message.Request.SearchTerm,
                        message.Payload.MetaData.JsonToObject<StopWatchResults>().ElapsedTime.ToString(),
                        message.RequestId, "Lace"),
                    new MonitoringActionIdentifier(DataProviderAction.Request.ToString())));

            _monitoring.Add(request);
        }
    }
}
 