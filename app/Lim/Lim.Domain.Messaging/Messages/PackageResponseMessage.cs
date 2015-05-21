using System;

namespace Lim.Domain.Messaging.Messages
{
    public class PackageResponseMessage
    {
        public PackageResponseMessage(Guid packageId, Guid userId, Guid contractId, string accountNumber, string payload, Guid requestId)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = DateTime.UtcNow;
            Payload = payload;
            RequestId = requestId;
            HasData = !string.IsNullOrEmpty(payload);
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
        public string Payload { get; private set; }
        public bool HasData { get; private set; }
    }
}