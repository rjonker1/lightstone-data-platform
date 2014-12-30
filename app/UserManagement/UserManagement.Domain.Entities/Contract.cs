using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Contract : Entity
    {
        public Contract()
        {
            Package = new HashSet<Package>();
        }

        public DateTime ContractCommencementDate { get; set; }
        public Guid ContractDurationId { get; set; }
        public Guid ContractTypeId { get; set; }
        public Guid EscalationTypeId { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Nullable<Guid> ClientId { get; set; }
        public string ContactDetail { get; set; }
        public Nullable<Guid> CustomerProfileId { get; set; }
        public string EnteredIntoBy { get; set; }
        public Nullable<DateTime> OnlineAcceptance { get; set; }
        public string RegisteredName { get; set; }
        public string RegistrationNumber { get; set; }

        public virtual Client Client { get; set; }
        public virtual CustomerProfile CustomerProfile { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual EscalationType EscalationType { get; set; }
        public virtual ContractDuration ContractDuration { get; set; }
        public virtual ICollection<Package> Package { get; set; }
    }
}
