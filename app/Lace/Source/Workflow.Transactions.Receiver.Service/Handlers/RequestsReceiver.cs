using System;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using EasyNetQ;
using Lace.Shared.Extensions;
using Monitoring.Domain;
using Monitoring.Domain.Identifiers;
using Monitoring.Domain.Repository;
using Workflow.Billing.Messages;
using Workflow.Lace.Domain;
using Workflow.Lace.Identifiers;
using Workflow.Lace.Messages.Events;
using Workflow.Lace.Messages.Infrastructure;

namespace Workflow.Transactions.Receiver.Service.Handlers
{
    public class RequestsReceiver
    {
        private readonly ITransactionRepository _transaction;
        private readonly IMonitoringRepository _monitoring;

        public RequestsReceiver(ITransactionRepository transaction, IMonitoringRepository monitoring)
        {
            _transaction = transaction;
            _monitoring = monitoring;
        }

        public void Consume(IMessage<RequestToDataProvider> message)
        {
            var request =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Body.Id,
                    message.Body.Date, new RequestIdentifier(message.Body.RequestId, null),
                    message.Body.DataProvider, message.Body.Connection,
                    new ActionIdentifier((int) message.Body.DataProvider.Action, message.Body.DataProvider.Action.ToString()),
                    new StateIdentifier((int) message.Body.DataProvider.State, message.Body.DataProvider.State.ToString()),
                    new NoRecordBillableIdentifier((int)message.Body.DataProvider.BillNoRecords, message.Body.DataProvider.BillNoRecords.ToString())));
            _transaction.Add(request);
        }

        public void Consume(IMessage<EntryPointReceivedRequest> message)
        {
            var request =
                new MonitoringDataProviderTransaction(new MonitoringDataProviderIdentifier(Guid.NewGuid(), message.Body.Date,
                    new SearchIdentifier(message.Body.Request.PackageName, message.Body.Request.PackageVersion,
                        message.Body.Payload.MetaData.JsonToObject<PerformanceMetadata>().Results.ElapsedTime.ToString(),
                        message.Body.RequestId, message.Body.Request.NumberOfDataProviders),
                    new MonitoringActionIdentifier(DataProviderAction.Request.ToString())));

            _monitoring.Add(request);
        }
    }
}
