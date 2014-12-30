using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class ClientPackage : Entity
    {
        public Guid ClientId { get; set; }
        public Guid PackageId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Package Package { get; set; }
    }
}
