using System;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace Workflow.Lace.Messages.Commands
{
    public class CreateTransactionCommand
    {
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public Guid PackageId { get; private set; }
        [DataMember]
        public long PackageVersion { get; private set; }
        [DataMember]
        public DateTime Date { get; private set; }
        [DataMember]
        public Guid UserId { get; private set; }
        [DataMember]
        public Guid RequestId { get; private set; }
        [DataMember]
        public Guid ContractId { get; private set; }

        [DataMember]
        public long ContractVersion { get; private set; }
        [DataMember]
        public string System { get; private set; }

        [DataMember]
        public DataProviderState State { get; private set; }

        [DataMember]
        public string AccountNumber { get; private set; }

        public CreateTransactionCommand(Guid id, Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId, Guid contractId,
            string system, long contractVersion, DataProviderState state, string accountNumber)
        {
            Id = id;
            PackageId = packageId;
            PackageVersion = packageVersion;
            Date = date;
            UserId = userId;
            RequestId = requestId;
            ContractId = contractId;
            System = system;
            State = state;
            ContractVersion = contractVersion;
            AccountNumber = accountNumber;
        }
    }
}
