using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using Monitoring.Domain;
using Monitoring.Domain.Identifiers;
using Monitoring.Domain.Repository;
using NServiceBus;
using Shared.BuildingBlocks.AdoNet.Repository;
using Workflow.Billing.Messages;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Response : IHandleMessages<ResponseFromDataProvider>, IHandleMessages<EntryPointReturnedResponse>
    {
        private readonly ITransactionRepository _transaction;
        private readonly IMonitoringRepository _monitoring;

        public Response()
        {

        }

        public Response(ITransactionRepository transaction, IMonitoringRepository monitoring)
        {
            _transaction = transaction;
            _monitoring = monitoring;
        }


        public void Handle(ResponseFromDataProvider message)
        {
            var response =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Id,
                    message.Date, new RequestIdentifier(message.Id, null),
                    message.DataProvider, message.Connection,
                    new ActionIdentifier((int) message.DataProvider.Action, message.DataProvider.Action.ToString()),
                    new StateIdentifier((int) message.DataProvider.State, message.DataProvider.State.ToString())));
            _transaction.Add(response);
        }

        public void Handle(EntryPointReturnedResponse message)
        {
            var response =
                new MonitoringDataProviderTransaction(new MonitoringDataProviderIdentifier(Guid.NewGuid(), message.Date,
                    new SearchIdentifier(message.RequestContext.Type, message.RequestContext.SearchTerm, message.Payload.MetaData,
                        message.RequestId, "Lace"),
                    new MonitoringActionIdentifier(DataProviderAction.Response.ToString())));
            _monitoring.Add(response);
        }
    }
}
