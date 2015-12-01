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
    public class ResponsesReceiver
    {
        private readonly ITransactionRepository _transaction;
        private readonly IMonitoringRepository _monitoring;

        public ResponsesReceiver(ITransactionRepository transaction, IMonitoringRepository monitoring)
        {
            _transaction = transaction;
            _monitoring = monitoring;
        }

        public void Consume(IMessage<ResponseFromDataProvider> message)
        {
            var response =
                new DataProviderTransaction(new DataProviderTransactionIdentifier(Guid.NewGuid(), message.Body.Id,
                    message.Body.Date, new RequestIdentifier(message.Body.RequestId, null),
                    message.Body.DataProvider, message.Body.Connection,
                    new Lace.Identifiers.ActionIdentifier((int) message.Body.DataProvider.Action, message.Body.DataProvider.Action.ToString()),
                    new StateIdentifier((int) message.Body.DataProvider.State, message.Body.DataProvider.State.ToString()),
                    new NoRecordBillableIdentifier((int) message.Body.DataProvider.BillNoRecords, message.Body.DataProvider.BillNoRecords.ToString()),message.Body.ReferenceNumber));
            _transaction.Add(response);
        }

        public void Consume(IMessage<EntryPointReturnedResponse> message)
        {
            var response =
                new MonitoringDataProviderTransaction(new MonitoringDataProviderIdentifier(Guid.NewGuid(), message.Body.Date,
                    new SearchIdentifier(message.Body.RequestContext.PackageName, message.Body.RequestContext.PackageVersion,
                        message.Body.Payload.MetaData.JsonToObject<PerformanceMetadata>().Results.ElapsedTime.ToString(),
                        message.Body.RequestId, message.Body.RequestContext.NumberOfDataProviders),
                    new Monitoring.Domain.Identifiers.ActionIdentifier(DataProviderAction.Response.ToString())));
            _monitoring.Add(response);

            
        }
    }
}
