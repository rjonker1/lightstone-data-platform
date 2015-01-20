using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerProfile : Entity
    {

        public virtual Guid CommercialStateId { get; set; }
        public virtual Guid CreateSourceId { get; set; }
        public virtual DateTime FirstCreateDate { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual Guid PlatformStatusId { get; set; }
        public virtual Guid? BillingId { get; set; }
        public virtual string PastelID { get; set; }
        public virtual Guid? ProfileDetailId { get; set; }

        public virtual Billing Billing { get; set; }
        public virtual CommercialState CommercialState { get; set; }
        public virtual CreateSource CreateSource { get; set; }
        public virtual ICollection<Customer> Customer { get; set; }
        public virtual PlatformStatus PlatformStatus { get; set; }
        public virtual ProfileDetail ProfileDetail { get; set; }

        public CustomerProfile()
        {
            Customer = new HashSet<Customer>();
        }

    }
}
