using System;
using System.Runtime.Serialization;
using CommonDomain;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
using Workflow.Lace.Messages.Core;
using Workflow.Lace.Messages.Events;

namespace Workflow.Lace.Domain.Aggregates
{
    [Serializable]
    [DataContract]
    public class Request : AggregateBase, IAggregate
    {
        private Request(Guid id)
        {
            Id = id;
            Register<RequestToDataProvider>(e => e.Id = id);
            Register<ResponseFromDataProvider>(e => e.Id = id);
            Register<TransactionCreated>(e => e.Id = id);
        }

        public Request(Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, DataProviderAction action, DataProviderState state, string connection, string connectionType)
            : this(requestId)
        {
            RequestId = requestId;
            Date = date;
            State = state;
            Action = action;
            DataProvider = dataProvider;

            RaiseEvent(new RequestToDataProvider(Guid.NewGuid(), requestId, dataProvider, date, connection,
                connectionType,
                state, action));
            //RaiseEvent(new RequestReceived(requestId, date));
        }

        public void RequestSentToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, string connectionType, string connection, DataProviderAction action, DataProviderState state)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;

            RaiseEvent(new RequestToDataProvider(id, requestId, dataProvider, date, connection, connectionType,
                state, action));
        }

        public void ResponseReceivedFromDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, string connection, string connectionType, DataProviderAction action, DataProviderState state)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            Date = date;
            State = state;
            Action = action;
            ConnectionType = connectionType;
            Connection = connection;

            RaiseEvent(new ResponseFromDataProvider(id, requestId, dataProvider, date, connection, connectionType, state,
                action));
        }

        public void CreateTransaction(Guid id, Guid packageId, long packageVersion, DateTime date, Guid userId,
            Guid requestId,
            Guid contractId,
            string system, long contractVersion, DataProviderState state)
        {
            RequestId = requestId;
            Date = date;
            ContractId = contractId;
            PackageId = packageId;
            PackageVersion = packageVersion;
            ContractVersion = contractVersion;
            State = state;

            RaiseEvent(new TransactionCreated(new PackageIdentifier(packageId, new VersionIdentifier(packageVersion)),
                new UserIdentifier(userId), new RequestIdentifier(requestId, new SystemIdentifier(system)), date, id));
        }

        public static Request ReceiveRequest(Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date, DataProviderAction action, DataProviderState state, string connection, string connectionType)
        {
            return new Request(requestId, dataProvider, date, action, state, connection, connectionType);
        }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public Guid PackageId { get; private set; }

        [DataMember]
        public long PackageVersion { get; private set; }

        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public long ContractVersion { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public DataProviderState State { get; private set; }

        [DataMember]
        public DataProviderAction Action { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public string Connection { get; private set; }

        [DataMember]
        public string ConnectionType { get; private set; }
    }
}
