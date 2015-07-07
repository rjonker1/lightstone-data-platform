using System;
using DataPlatform.Shared.Messaging.Billing.Helpers;

namespace Workflow.Billing.Domain.Entities
{
    public class PackageMeta : Entity
    {
        public virtual Guid PackageId { get; set; }
        public virtual string PackageName { get; set; }
        public virtual double PackageCos { get; set; }
        public virtual double PackageRsp { get; set; }

        public PackageMeta() { }
    }
}