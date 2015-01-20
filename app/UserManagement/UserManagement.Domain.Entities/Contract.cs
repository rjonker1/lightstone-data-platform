using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Contract : Entity
    {

        public virtual DateTime ContractCommencementDate { get; set; }
        public virtual Guid ContractDurationId { get; set; }
        public virtual string ContractName { get; set; }
        public virtual Guid ContractTypeId { get; set; }
        public virtual Guid EscalationTypeId { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual Nullable<Guid> ClientId { get; set; }
        public virtual string ContactDetail { get; set; }
        public virtual string EnteredIntoBy { get; set; }
        public virtual Nullable<DateTime> OnlineAcceptance { get; set; }
        public virtual Nullable<Guid> ProfileDetailId { get; set; }
        public virtual string RegisteredName { get; set; }
        public virtual string RegistrationNumber { get; set; }

        public virtual Client Client { get; set; }
        public virtual ProfileDetail ProfileDetail { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual EscalationType EscalationType { get; set; }
        public virtual ContractDuration ContractDuration { get; set; }
        public virtual ICollection<ContractPackage> ContractPackage { get; set; }

        public Contract()
        {
            this.ContractPackage = new HashSet<ContractPackage>();
        }
    }
}
