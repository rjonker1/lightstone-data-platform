using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;
using DataPlatform.Shared.Messaging;

namespace Workflow.Billing.Messages
{
    [Serializable]
    [DataContract]
    public class BillTransactionMessage : IPublishableMessage
    {
        public BillTransactionMessage()
        {
        }

        public BillTransactionMessage(PackageIdentifier packageIdentifier, UserIdentifier userIdentifier,
            RequestIdentifier requestIdentifier,
            DateTime transactionDate, Guid transactionId, StateIdentifier state, ContractIdentifier contract, AccountIdentifier account)
        {
            PackageIdentifier = packageIdentifier;
            UserIdentifier = userIdentifier;
            RequestIdentifier = requestIdentifier;
            TransactionDate = transactionDate;
            TransactionId = transactionId;
            State = state;
            Contract = contract;
            Account = account;
        }

        [DataMember]
        public PackageIdentifier PackageIdentifier { get; set; }
        [DataMember]
        public UserIdentifier UserIdentifier { get; set; }
        [DataMember]
        public RequestIdentifier RequestIdentifier { get; set; }
        [DataMember]
        public DateTime TransactionDate { get; set; }
        [DataMember]
        public Guid TransactionId { get; set; }
        [DataMember]
        public StateIdentifier State { get; set; }
        [DataMember]
        public ContractIdentifier Contract { get; set; }
        [DataMember]
        public AccountIdentifier Account { get; set; }
    }
}