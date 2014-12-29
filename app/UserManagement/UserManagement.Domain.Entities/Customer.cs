using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Customer : Entity
    {

        public virtual Guid Id { get; protected internal set; }
        public virtual string CustomerName { get; protected internal set; }
        public virtual Guid AccountOwnerId { get; protected internal set; }
        public virtual Guid CustomerProfileId { get; protected internal set; }
        public virtual Guid ProvinceId { get; protected internal set; }

    }
}
