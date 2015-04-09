using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Identifiers;

namespace Workflow.Billing.Domain
{
    [Serializable]
    [DataContract]
    public class Transaction
    {
        public Transaction()
        {
        }

        public Transaction(Guid id, DateTime date, PackageIdentifier package, RequestIdentifier request, UserIdentifier user, StateIdentifier state, ContractIdentifier contract, AccountIdentifier account)
        {
            Id = id;
            Date = date;
            Package = package;
            Request = request;
            User = user;
            State = state;
            Contract = contract;
            Account = account;
        }

        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public PackageIdentifier Package { get; private set; }
        [DataMember]
        public RequestIdentifier Request { get; private set; }
        [DataMember]
        public UserIdentifier User { get; private set; }
        [DataMember]
        public StateIdentifier State { get; private set; }
        [DataMember]
        public ContractIdentifier Contract { get; private set; }
        [DataMember]
        public AccountIdentifier Account { get; private set; }

    }
}