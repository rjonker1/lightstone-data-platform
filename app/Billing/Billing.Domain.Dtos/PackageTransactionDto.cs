using System;

namespace Billing.Domain.Dtos
{
    public class PackageTransactionDto
    {
        public Guid PackageId { get; set; }
        public string PackageName { get; set; }
    }
}