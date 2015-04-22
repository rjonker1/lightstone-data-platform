using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;
using DataPlatform.Shared.Messaging;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Events
{
    [Serializable]
    [DataContract]
    public class EntryPointReceivedRequest : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

        [DataMember]
        public SearchRequestIndentifier Request { get; private set; }

        public EntryPointReceivedRequest(Guid id, DateTime date, Guid requestId, PayloadIdentifier payload,
            SearchRequestIndentifier request)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Payload = payload;
            Request = request;
        }
    }

    [Serializable]
    [DataContract]
    public class EntryPointReturnedResponse : IPublishableMessage
    {
        [DataMember]
        public Guid Id { get; set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

        [DataMember]
        public StateIdentifier State { get; private set; }

        [DataMember]
        public SearchRequestIndentifier RequestContext { get; private set; }

        public EntryPointReturnedResponse(Guid id, Guid requestId, DateTime date, PayloadIdentifier payload,
            StateIdentifier state,SearchRequestIndentifier request)
        {
            Id = id;
            RequestId = requestId;
            Date = date;
            Payload = payload;
            State = state;
            RequestContext = request;
        }
    }
}
