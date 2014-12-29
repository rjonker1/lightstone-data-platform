using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Contract : Entity
    {

        public virtual Guid Id { get; protected internal set; }
        public virtual DateTime ContractCommencementDate { get; protected internal set; }
        public virtual Guid ContractDurationId { get; protected internal set; }
        public virtual Guid EscalationTypeId { get; protected internal set; }
        public virtual string LastUpdateBy { get; protected internal set; }
        public virtual DateTime LastUpdateDate { get; protected internal set; }
        public virtual Guid ClientId { get; protected internal set; }
        public virtual string ContactDetail { get; protected internal set; }
        public virtual Guid CustomerProfileId { get; protected internal set; }
        public virtual string EnteredIntoBy { get; protected internal set; }
        public virtual DateTime OnlineAcceptance { get; protected internal set; }
        public virtual string RegisteredName { get; protected internal set; }
        public virtual string RegistratoinNumber { get; protected internal set; }

    }
}
