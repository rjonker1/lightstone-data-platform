using System;

namespace Billing.Domain.Dtos
{
    public class PackageTransactionDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string OriginalValue { get; set; }
    }
}