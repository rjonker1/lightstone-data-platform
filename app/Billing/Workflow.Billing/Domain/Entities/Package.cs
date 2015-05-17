using System;

namespace Workflow.Billing.Domain.Entities
{
    public class Package : DataProvider
    {
        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }
        public virtual double Price { get; set; }
    }
}