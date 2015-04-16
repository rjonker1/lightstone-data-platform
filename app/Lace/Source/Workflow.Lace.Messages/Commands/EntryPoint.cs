using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using DataPlatform.Shared.Identifiers;
using Lace.Domain.Core.Requests.Contracts;
using Workflow.Lace.Identifiers;

namespace Workflow.Lace.Messages.Commands
{
    [Serializable]
    [DataContract]
    public class ReceiveEntryPointRequest
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public SearchRequestIndentifier Request { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }

        public ReceiveEntryPointRequest(Guid id, Guid requestId,
            DateTime date, SearchRequestIndentifier request, PayloadIdentifier payload)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Request = request;
            Payload = payload;

        }
    }

    [Serializable]
    [DataContract]
    public class ReturnEntryPointResponse
    {
        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public Guid RequestId { get; private set; }

        [DataMember]
        public StateIdentifier State { get; private set; }

        [DataMember]
        public PayloadIdentifier Payload { get; private set; }
        [DataMember]
        public SearchRequestIndentifier Request { get; private set; }

        public ReturnEntryPointResponse(Guid id, Guid requestId,
            DateTime date, StateIdentifier state, PayloadIdentifier payload,SearchRequestIndentifier request)
        {
            Id = id;
            Date = date;
            RequestId = requestId;
            Payload = payload;
            State = state;
            Request = request;
        }
    }
}
