using System;
using System.Runtime.Serialization;
using Lim.Core;

namespace Lim.Domain.Events
{
    [DataContract]
    public class PackageReceived : IMessage
    {

        public PackageReceived(Guid packageId, Guid userId, Guid contractId, int accountNumber, Guid requestId)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = DateTime.UtcNow;
            RequestId = requestId;
        }

        [DataMember] public readonly Guid PackageId;
        [DataMember] public readonly Guid UserId;
        [DataMember] public readonly Guid ContractId;
        [DataMember] public readonly int AccountNumber;
        [DataMember] public readonly DateTime ResponseDate;
        [DataMember] public readonly Guid RequestId;
    }
}