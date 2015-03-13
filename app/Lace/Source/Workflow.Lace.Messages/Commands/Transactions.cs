using System;
using System.Runtime.Serialization;

namespace Workflow.Lace.Messages.Commands
{
    public class CreateTransactionCommand
    {
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
        public string System { get; private set; }

        public CreateTransactionCommand(Guid packageId, long packageVersion, DateTime date, Guid userId, Guid requestId, Guid contractId,
            string system)
        {
            PackageId = packageId;
            PackageVersion = packageVersion;
            Date = date;
            UserId = userId;
            RequestId = requestId;
            ContractId = contractId;
            System = system;
        }
    }
}
