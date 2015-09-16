using System;
using System.Linq;
using Lim.Domain.Extensions;

namespace Lim.Domain.Messaging.Messages
{
    public class PackageConfigurationMessage
    {
        public PackageConfigurationMessage(Guid packageId, Guid userId, Guid contractId, string accountNumber, Guid requestId)
        {
            PackageId = packageId;
            UserId = userId;
            ContractId = contractId;
            AccountNumber = accountNumber.HasDigit() ? (string.Join("", accountNumber.Where(Char.IsNumber)).TrimStart('0')).Check() : -1;
            ResponseDate = DateTime.UtcNow;
            RequestId = requestId;
        }

        private static bool HasDigit(string value)
        {
            return value.Any(Char.IsDigit);
        }

        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public Guid ContractId { get; private set; }
        public int AccountNumber { get; private set; }
        public DateTime ResponseDate { get; private set; }
        public Guid RequestId { get; private set; }
    }
}