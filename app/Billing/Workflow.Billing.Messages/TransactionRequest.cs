using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
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

        public TransactionRequest(Guid id, RequestIdentifier request, UserIdentifier user, StateIdentifier state, DateTime date)
        {
            Id = id;
            Request = request;
            User = user;
            State = state;
            Date = date;
            ExpirationDate = DateTime.Now.AddDays(1);
        }

        public void Audit(ITransactionRepository transaction)
        {
            if (State.Id == (int) DataProviderResponseState.VinShort)
                transaction.Add(this);
        }


        [DataMember]
        public Guid Id { get; private set; }

        [DataMember]
        public RequestIdentifier Request { get; private set; }

        [DataMember]
        public UserIdentifier User { get; private set; }

        [DataMember]
        public StateIdentifier State { get; private set; }

        [DataMember]
        public DateTime Date { get; private set; }

        [DataMember]
        public DateTime ExpirationDate { get; private set; }
    }
}
