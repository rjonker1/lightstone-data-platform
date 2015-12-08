using System;

namespace Lim.Domain.Messaging.Messages
{
    [Obsolete("Use SendExecutedPackage")]
    public class PackageResponseMessage
    {
        public PackageResponseMessage(Guid packageId, Guid userId, Guid contractId, string accountNumber, string payload, Guid requestId, string username)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = DateTime.UtcNow;
            Payload = payload;
            RequestId = requestId;
            HasData = !string.IsNullOrEmpty(payload);
            Username = username;
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public string Username { get; private set; }
        public Guid ContractId { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
        public string Payload { get; private set; }
        public bool HasData { get; private set; }
    }
}