using System;
using System.Linq;

namespace Lim.Domain.Messaging.Messages
{
    [Obsolete("Use ExecutedPackageSent")]
    public class PackageConfigurationMessage
    {
        public PackageConfigurationMessage(Guid packageId, Guid userId, Guid contractId, int accountNumber, Guid requestId)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber;  //accountNumber.HasDigit() ? (string.Join("", accountNumber.Where(char.IsNumber)).TrimStart('0')).Check() : -1;
            ResponseDate = DateTime.UtcNow;
            RequestId = requestId;
        }

        private static bool HasDigit(string value)
        {
            return value.Any(char.IsDigit);
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public int AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
    }
}