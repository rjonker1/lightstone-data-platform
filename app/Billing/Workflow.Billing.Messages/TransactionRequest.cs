using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class TransactionRequest
    {
        public TransactionRequest()
        {
            
        }

        public TransactionRequest(Guid id, RequestIdentifier request, UserIdentifier user, StateIdentifier responseState, DateTime date,
            DateTime expirationDate)
        {
            Id = id;
            Request = request;
            User = user;
            ResponseState = responseState;
            Date = date;
            ExpirationDate = expirationDate;
        }
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public RequestIdentifier Request { get; private set; }
        [DataMember]
        public UserIdentifier User { get; private set; }
        [DataMember]
        public StateIdentifier ResponseState { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public DateTime ExpirationDate { get; private set; }
    }
}
