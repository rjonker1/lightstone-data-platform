using System;

namespace Workflow.Billing.Domain.Entities
{
    public class Package : DataProvider
    {
        public virtual Guid PackageId { get; set; }
    }
}