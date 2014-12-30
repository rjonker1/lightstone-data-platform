using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerProfile : Entity
    {
        public CustomerProfile()
        {
            Contract = new HashSet<Contract>();
            Customer = new HashSet<Customer>();
        }

        public Guid CommercialStateId { get; set; }
        public Guid CreateSourceId { get; set; }
        public DateTime FirstCreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid PlatformStatusId { get; set; }
        public Nullable<Guid> BillingId { get; set; }
        public string PastelID { get; set; }

        public virtual Billing Billing { get; set; }
        public virtual CommercialState CommercialState { get; set; }
        public virtual ICollection<Contract> Contract { get; set; }
        public virtual CreateSource CreateSource { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual PlatformStatus PlatformStatus { get; set; }
    }
}
