using System;

namespace Lim.Domain.Messaging.Messages
{
    public class PackageConfigurationMessage
    {
        public PackageConfigurationMessage(Guid packageId, Guid userId, Guid contractId, string accountNumber, Guid requestId)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = DateTime.UtcNow;
            RequestId = requestId;
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
    }
}