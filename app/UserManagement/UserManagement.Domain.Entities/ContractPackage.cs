using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ContractPackage //: Entity
    {

        public virtual Guid ContractId { get; set; }
        public virtual Guid PackageId { get; set; }

        public virtual Contract Contract { get; set; }
        public virtual Package Package { get; set; }

    }
}