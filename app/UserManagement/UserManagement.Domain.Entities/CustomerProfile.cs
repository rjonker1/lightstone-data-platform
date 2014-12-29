using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerProfile : Entity
    {

        public virtual Guid Id { get; protected internal set; }
        public virtual Guid CommercialStateId { get; protected internal set; }
        public virtual Guid CreateSourceId { get; protected internal set; }
        public virtual DateTime FirstCreateDate { get; protected internal set; }
        public virtual string LastUpdateBy { get; protected internal set; }
        public virtual DateTime LastUpdateDate { get; protected internal set; }
        public virtual Guid PlatformStatusId { get; protected internal set; }
        public virtual Guid BillingId { get; protected internal set; }
        public virtual string PastelId { get; protected internal set; }

    }
}
