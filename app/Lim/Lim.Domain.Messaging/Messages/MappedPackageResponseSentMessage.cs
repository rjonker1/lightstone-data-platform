using System;

namespace Lim.Domain.Messaging.Messages
{
    public class MappedPackageResponseSentMessage
    {
        public MappedPackageResponseSentMessage(Guid packageId, Guid userId, Guid contractId, string accountNumber, string payload)
        {
            PacakgeId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;
            ResponseDate = DateTime.UtcNow;
            Payload = payload;
        }

        public Guid PacakgeId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public string AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public string Payload { get; private set; }
    }
}
