using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class CustomerProfile : Entity
    {

        public virtual DateTime FirstCreateDate { get; set; }
        public virtual string LastUpdateBy { get; set; }
        public virtual DateTime LastUpdateDate { get; set; }
        public virtual string PastelID { get; set; }

        public virtual Billing Billing { get; set; }
        public virtual CommercialState CommercialState { get; set; }
        public virtual CreateSource CreateSource { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual PlatformStatus PlatformStatus { get; set; }
        public virtual ProfileDetail ProfileDetail { get; set; }

        protected CustomerProfile() { }

        public CustomerProfile(Guid id, DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string pastelId, Billing billing, CommercialState commercialState, 
                                CreateSource createSource, Customer customer, PlatformStatus platformStatus/*, ProfileDetail profileDetail*/)
            : base(id)
        {

            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            PastelID = pastelId;
            Billing = billing;
            CommercialState = commercialState;
            CreateSource = createSource;
            Customer = customer;
            PlatformStatus = platformStatus;
            //ProfileDetail = profileDetail;
        }
    }
}
