using System;
using System.Runtime.Serialization;
using CommonDomain;
using CommonDomain.Core;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.Identifiers;
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
            Register<RequestReceived>(e => e.Id = id);
            Register<RequestSentToDataProvider>(e => e.Id = id);
            Register<ResponseReceivedFromDataProvider>(e => e.Id = id);
            Register<ResponseReturned>(e => e.Id = id);
            Register<TransactionCreated>(e => e.Id = id);
        }

        public Request(Guid requestId, DateTime date)
            : this(requestId)
        {
            RequestId = requestId;
            Date = date;

            RaiseEvent(new RequestReceived(requestId, date));
        }

        public void RequestSentToDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            object payload,
            DateTime date, string connectionType, string connection)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            //ResponsePayload = payload;
            Date = date;

            RaiseEvent(new RequestSentToDataProvider(id, requestId, dataProvider, date, connection, connectionType));
        }

        public void ResponseReceivedFromDataProvider(Guid id, Guid requestId, DataProviderCommandSource dataProvider,
            DateTime date)
        {
            RequestId = requestId;
            DataProvider = dataProvider;
            //RequestPayload = payload;
            Date = date;

            RaiseEvent(new ResponseReceivedFromDataProvider(id, requestId, dataProvider, date));
        }

        public void ReturnResponse(Guid id, Guid requestId, DateTime date)
        {
            RequestId = requestId;
            Date = date;

            RaiseEvent(new ResponseReturned(id, requestId, date));
        }

        public void CreateTransaction(Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId,
            Guid contractId,
            string system)
        {
            RequestId = requestId;
            Date = date;

            RaiseEvent(new TransactionCreated(new PackageIdentifier(packageId, new VersionIdentifier(packageVersion)),
                new UserIdentifier(userId), new RequestIdentifier(requestId, new SystemIdentifier(system)), date));
        }

        public static Request ReceiveRequest(Guid requestId, DateTime date)
        {
            return new Request(requestId, date);
        }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DataProviderCommandSource DataProvider { get; private set; }

        [DataMember]
        public object RequestPayload { get; private set; }

        //[DataMember]
        //public object ResponsePayload { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }
    }
}
