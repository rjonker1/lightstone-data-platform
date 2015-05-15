using System;

namespace Lim.Push.Models
{
    public class Transaction
    {
        public Guid TransactionId { get; private set; }
        public Guid PackageId { get; private set; }
        public Guid UserId { get; private set; }
        public string Payload { get; private set; }
    }
}
